using DynamicLINQ.Configurations.LinqConfigurations.Contracts;
using DynamicLINQ.Configurations.LinqConfigurations.Enums;

namespace DynamicLINQ.Configurations.LinqConfigurations.Statements
{
	public class WhereStatement : IWhereStatement
	{
		public LogicalOperator LogicalOperator { get; set; }

		public Operator Operator { get; set; }

		public string PropertyName { get; set; }

		public object Value { get; set; }
	}
}
