
using System.Collections.Generic;

namespace DynamicLINQ.Configurations.LinqConfigurations.Contracts
{
	public interface IDynamicModelConfiguration
	{
		string Table { get; set; }

		ICollection<IWhereStatement> Wheres { get; set; }

		ICollection<ISelectStatement> Selects { get; set; }

		IOrderByStatement OrderBy { get; set; }

		IThenByStatement ThenBy { get; set; }
	}
}
