using System;
using System.Collections.Generic;
using DynamicLINQ.Configurations.LinqConfigurations.Contracts;

namespace DynamicLINQ.Configurations.LinqConfigurations
{
	public class Configurations : IConfiguration
	{
		public Configurations()
		{
			DynamicModelConfigurations = new HashSet<IDynamicModelConfiguration>();
		}

		public ICollection<IDynamicModelConfiguration> DynamicModelConfigurations { get; set; }
	}
}
