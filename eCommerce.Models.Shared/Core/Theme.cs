﻿using eCommerce.Models.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.Shared.Core
{
    public class Theme : File, IDatabaseEntity
    {
        public int Id { get; set; }
    }
}
