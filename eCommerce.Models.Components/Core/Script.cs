using eCommerce.Models.Shared.Contracts;
using eCommerce.Models.Shared.Core;

namespace eCommerce.Models.Components.Core
{
    public class Script : File, IDatabaseEntity
    {
        public int Id { get; set; }
    }
}
