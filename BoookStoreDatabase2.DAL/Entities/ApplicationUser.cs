
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoookStoreDatabase2.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Employee")]
        public int ? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("Customer")]
        public int ? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
