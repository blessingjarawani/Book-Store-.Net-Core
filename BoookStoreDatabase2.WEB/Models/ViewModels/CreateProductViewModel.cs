using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary.Dictionary;

namespace BoookStoreDatabase2.WEB.Models.ViewModels
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ProductType ProductType { get; set; }
    }
}
