using eCommerce.Models.Components.Contracts;
using eCommerce.Models.Components.Core.DatabaseConfigurations;
using eCommerce.Models.Shared.Contracts;
using eCommerce.Models.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Components.Core
{
    public class Component : IDatabaseEntity, IComponent
    {
        public Component()
        {
            this.Themes = new List<Theme>();
        }

        public int Id { get; set; }
        public string RazorView { get; set; }
        public int ScriptId { get; set; }
        public int StyleId { get; set; }
        public virtual Script Script { get; set; }
        public virtual Style Style { get; set; }
        public virtual IEnumerable<Theme> Themes { get; set; }
        public ComponentType ComponentType { get; set; }
        public DatabaseConfiguration DatabaseConfigurations { get; set; }
    }
}
