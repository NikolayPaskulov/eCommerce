using eCommerce.Models.Components.Core;
using eCommerce.Models.Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Components.Contracts
{
    public interface IComponent : IRazorComponent
    {
        Script Script { get; set; }
        Style Style { get; set; }
        IEnumerable<Theme> Themes { get; set; }
    }
}
