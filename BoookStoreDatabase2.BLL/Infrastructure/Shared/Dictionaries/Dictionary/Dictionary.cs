using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary
{
    public static class Dictionary
    {
        public enum CartStatus
        {
            Inprogress = 0,
            Proccessed = 1
        }

        public enum ProductType
        {
            Books = 1,
            Movies = 2
        }

        public enum Roles
        {
            Employee = 0,
            Customer = 1
        }
    }
}
