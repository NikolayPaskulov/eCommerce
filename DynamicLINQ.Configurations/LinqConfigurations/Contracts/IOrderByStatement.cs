using DynamicLINQ.Configurations.LinqConfigurations.Enums;

namespace DynamicLINQ.Configurations.LinqConfigurations.Contracts
{
	public interface IOrderByStatement
	{
		string PropertyName { get; set; }
		OrderDirection Direction { get; set; }
	}
}
