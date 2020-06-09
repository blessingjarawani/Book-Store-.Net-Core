using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.BLL.Models.DTO
{
    public class OrderLineDTO
    {
        public List<ProductsDTO> Products { get; set; }
        public int CustomerId { get; set; }

    }
}
