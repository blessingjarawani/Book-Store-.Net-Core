
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Employee  Employee { get; set; }
        public virtual Customer  Customer { get; set; }
    }
}
