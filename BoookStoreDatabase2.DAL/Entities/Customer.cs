using BoookStoreDatabase2.DAL.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.DAL.Entities
{
    public class Customer : BasePerson
    {
        public  bool HasClubCard { get; set; }
    }
}
