using eCommerce.Models.Core;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Contexts
{
    public class eCommerceDbContext : IdentityDbContext<User>
    {
        public eCommerceDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static eCommerceDbContext Create()
        {
            return new eCommerceDbContext();
        }
    }
}
