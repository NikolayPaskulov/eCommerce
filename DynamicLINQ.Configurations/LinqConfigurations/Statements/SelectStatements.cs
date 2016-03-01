using DynamicLINQ.Configurations.LinqConfigurations.Contracts;

namespace DynamicLINQ.Configurations.LinqConfigurations.Statements
{
	public class SelectStatements : ISelectStatement
	{
		public string PropertyName { get; set; }

		public string VariableName { get; set; }
	}
}
