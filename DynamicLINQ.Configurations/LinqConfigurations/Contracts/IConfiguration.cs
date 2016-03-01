using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLINQ.Configurations.LinqConfigurations.Contracts
{
	public interface IConfiguration
	{
		ICollection<IDynamicModelConfiguration> DynamicModelConfigurations { get; set; }
	}
}
