using eCommerce.Models.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Shared.Core
{
    public class Theme : IDatabaseEntity, ITheme
    {
        public int Id { get; set; }

        public string FilePath { get; set; }
    }
}
