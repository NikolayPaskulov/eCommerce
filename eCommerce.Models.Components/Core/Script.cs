using eCommerce.Models.Components.Contracts;
using eCommerce.Models.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Components.Core
{
    public class Script : IDatabaseEntity, IFile
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
    }
}
