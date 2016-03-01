using DynamicLINQ.Configurations.LinqConfigurations.Contracts;
using eCommerce.Models.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Components.Core.DatabaseConfigurations
{
    public class SelectStatement : IDatabaseEntity, ISelectStatement
    {
        public int Id { get; set; }

        public string VariableName { get; set; }

        public string PropertyName { get; set; }
    }
}
