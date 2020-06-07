using System;
using System.Collections.Generic;
using System.Text;
using static BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary.Dictionary;

namespace BoookStoreDatabase2.BLL.Models.DTO
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ProductType ProductType { get; set; }
    }
}
