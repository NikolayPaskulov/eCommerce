using DynamicLINQ.Configurations.LinqConfigurations.Contracts;
using DynamicLINQ.Configurations.LinqConfigurations.Enums;

namespace DynamicLINQ.Configurations.LinqConfigurations.Statements
{
	public class OrderByStatement : IOrderByStatement
	{
		public OrderDirection Direction { get; set; }

		public string PropertyName { get; set; }
	}
}
