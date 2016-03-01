using DynamicLINQ.Configurations.LinqConfigurations.Contracts;
using DynamicLINQ.Configurations.LinqConfigurations.Enums;
using DynamicLINQ.Extensions.LinqExtensions.PredicateExtensions;
using DynamicLINQ.Extensions.LinqExtensions.TypeBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLINQ.Extensions.LinqExtensions
{
	public static class LinqExtensions
	{
		public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, IEnumerable<IWhereStatement> whereStatements)
		{
			if (whereStatements != null && whereStatements.Any())
			{
				var rules = Predicate.Begin<TSource>();

				foreach (var statement in whereStatements)
				{
					var param = Expression.Parameter(typeof(TSource), "whereParamType");
					Expression property = Expression.Property(param, statement.PropertyName);
					var constant = Expression.Constant(statement.Value);

					BinaryExpression expression = GenerateOperatorExpression(property, constant, statement.Operator);

					var predicate = Expression.Lambda<Func<TSource, bool>>(expression, param);

					if (statement.LogicalOperator == LogicalOperator.And)
						rules = rules.And(predicate);
					else
						rules = rules.Or(predicate);
				}

				source = source.Where(rules);
			}

			return source;
		}

		public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, IOrderByStatement orderBy) where TSource : class
		{
			if (orderBy != null)
			{
				if (orderBy.Direction == OrderDirection.Ascending)
					return source.OrderBy<TSource>(orderBy.PropertyName);
				else
					return source.OrderByDescending<TSource>(orderBy.PropertyName);
			}

			return (source as IOrderedQueryable<TSource>);
		}

		public static IOrderedQueryable<TSource> ThenBy<TSource>(this IOrderedQueryable<TSource> source, IThenByStatement thenBy) where TSource : class
		{
			if (thenBy != null)
			{
				if (thenBy.Direction == OrderDirection.Ascending)
					return source.ThenBy<TSource>(thenBy.PropertyName);
				else
					return source.ThenByDescending<TSource>(thenBy.PropertyName);
			}

			return source;
		}

		public static IQueryable<TResult> Select<TSource, TResult>(this IQueryable<TSource> source, IEnumerable<ISelectStatement> selectStatements)
		{
			return source as IQueryable<TResult>;
		}

		public static IQueryable<dynamic> Select<TSource>(this IQueryable<TSource> source, IEnumerable<ISelectStatement> selectStatements)
		{
			var sourceItem = Expression.Parameter(source.ElementType, "t");

			var sourceProperties = selectStatements.Where(x => source.ElementType.GetProperty(x.PropertyName) != null)
												.ToDictionary(x => x.VariableName, x => source.ElementType.GetProperty(x.PropertyName));

			var dynamicProperties = sourceProperties.ToDictionary(x => x.Key, x => x.Value.PropertyType);
			var dynamicType = DynamicTypeBuilder.GetDynamicType(dynamicProperties, typeof(object), Type.EmptyTypes);

			var bindings = dynamicType.GetFields()
									  .Select(p => Expression.Bind(p, Expression.Property(sourceItem, sourceProperties[p.Name])))
									  .OfType<MemberBinding>()
									  .ToList();

			var selector = Expression.Lambda<Func<TSource, dynamic>>(Expression.MemberInit(Expression.New(dynamicType.GetConstructor(Type.EmptyTypes)), bindings), sourceItem);

			return source.Select(selector);
		}

		private static LambdaExpression GenerateSelector<TEntity>(String propertyName, out Type resultType) where TEntity : class
		{
			// Create a parameter to pass into the Lambda expression (Entity => Entity.OrderByField).
			var parameter = Expression.Parameter(typeof(TEntity), "Entity");
			//  create the selector part, but support child properties
			PropertyInfo property;
			Expression propertyAccess;
			if (propertyName.Contains('.'))
			{
				// support to be sorted on child fields.
				String[] childProperties = propertyName.Split('.');
				property = typeof(TEntity).GetProperty(childProperties[0], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
				propertyAccess = Expression.MakeMemberAccess(parameter, property);
				for (int i = 1; i < childProperties.Length; i++)
				{
					property = property.PropertyType.GetProperty(childProperties[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
					propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
				}
			}
			else
			{
				property = typeof(TEntity).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
				propertyAccess = Expression.MakeMemberAccess(parameter, property);
			}
			resultType = property.PropertyType;
			// Create the order by expression.
			return Expression.Lambda(propertyAccess, parameter);
		}
		private static MethodCallExpression GenerateMethodCall<TEntity>(IQueryable<TEntity> source, string methodName, String fieldName) where TEntity : class
		{
			Type type = typeof(TEntity);
			Type selectorResultType;
			LambdaExpression selector = GenerateSelector<TEntity>(fieldName, out selectorResultType);
			MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName,
							new Type[] { type, selectorResultType },
							source.Expression, Expression.Quote(selector));
			return resultExp;
		}

		private static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
		{
			MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "OrderBy", fieldName);
			return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
		}

		private static IOrderedQueryable<TEntity> OrderByDescending<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
		{
			MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "OrderByDescending", fieldName);
			return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
		}
		private static IOrderedQueryable<TEntity> ThenBy<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
		{
			MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "ThenBy", fieldName);
			return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
		}
		private static IOrderedQueryable<TEntity> ThenByDescending<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
		{
			MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "ThenByDescending", fieldName);
			return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
		}


		private static BinaryExpression GenerateOperatorExpression(Expression property, ConstantExpression constant, Operator oper)
		{
			switch (oper)
			{
				case Operator.Equal:
					return Expression.Equal(property, constant);
				case Operator.NotEqual:
					return Expression.NotEqual(property, constant);
				case Operator.GreaterThen:
					return Expression.GreaterThan(property, constant);
				case Operator.LessThen:
					return Expression.LessThan(property, constant);
				case Operator.GreaterThenOrEqual:
					return Expression.GreaterThanOrEqual(property, constant);
				case Operator.LessThenOrEqual:
					return Expression.LessThanOrEqual(property, constant);
				default:
					throw new InvalidOperationException("There is no suitable operator!");
			}
		}
	}
}
