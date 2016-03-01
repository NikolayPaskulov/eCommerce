using DynamicLINQ.Configurations.LinqConfigurations.Contracts;
using DynamicLINQ.Configurations.LinqConfigurations.Enums;
using eCommerce.Models.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Components.Core.DatabaseConfigurations
{
    public class OrderByStatement : IDatabaseEntity, IOrderByStatement
    {
        public int Id { get; set; }

        public string PropertyName { get; set; }

        public OrderDirection Direction { get; set; }
    }
}
