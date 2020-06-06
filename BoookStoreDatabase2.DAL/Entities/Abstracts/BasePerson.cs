using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.DAL.Entities.Abstracts
{
    public abstract class BasePerson : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
    }
}
