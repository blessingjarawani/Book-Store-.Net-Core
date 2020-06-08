using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.BLL.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public ProductsDTO Products { get; set; }
    }
}
