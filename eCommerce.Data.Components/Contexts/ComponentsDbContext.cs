using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Components.Contexts
{
    public class ComponentsDbContext : DbContext
    {
        public ComponentsDbContext()
            : base("ComponentsConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Component> Components { get; set; }
    }
}
