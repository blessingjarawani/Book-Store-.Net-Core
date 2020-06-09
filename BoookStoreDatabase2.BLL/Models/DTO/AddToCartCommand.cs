using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.BLL.Models.DTO
{
    public class AddToCartCommand
    {
        public int CustomerId { get; set; }
        public ProductsDTO Product { get; set; }

        public bool IsValid => CustomerId > 0
            && Product != null && Product.Id > 0 &&
            Product.Price > 0 && Product.Quantity > 0;
    }
}
