using DynamicLINQ.Configurations.LinqConfigurations.Contracts;
using eCommerce.Models.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Components.Core.DatabaseConfigurations
{
    public class DatabaseConfiguration : IDatabaseEntity, IDynamicModelConfiguration
    {
        public DatabaseConfiguration()
        {
            this.Wheres = new List<WhereStatement>();
            this.Selects = new List<SelectStatement>();
        }

        public int Id { get; set; }

        public string Table { get; set; }

        public virtual ICollection<WhereStatement> Wheres { get; set; }

        public virtual ICollection<SelectStatement> Selects { get; set; }

        public OrderByStatement OrderBy { get; set; }

        public ThenByStatement ThenBy { get; set; }
    }
}
