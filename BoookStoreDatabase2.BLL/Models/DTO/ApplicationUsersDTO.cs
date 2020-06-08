using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.BLL.Models.DTO
{
    public class ApplicationUsersDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
    }
}
