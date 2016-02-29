using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Components.Contracts
{
    public interface IRazorComponent
    {
        string RazorView { get; set; }
    }
}
