using DynamicLINQ.Configurations.LinqConfigurations.Contracts;
using System.Collections.Generic;

namespace DynamicLINQ.Configurations.LinqConfigurations
{
	public class DynamicModelConfigurations : IDynamicModelConfiguration
	{
		public DynamicModelConfigurations()
		{
			Selects = new HashSet<ISelectStatement>();
			Wheres = new HashSet<IWhereStatement>();
		}

		public string Table { get; set; }

		public IOrderByStatement OrderBy { get; set; }

		public ICollection<ISelectStatement> Selects { get; set; }

		public IThenByStatement ThenBy { get; set; }

		public ICollection<IWhereStatement> Wheres { get; set; }
	}
}
