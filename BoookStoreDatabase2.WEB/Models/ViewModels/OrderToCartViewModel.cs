using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.WEB.Models.ViewModels
{
    public class OrderToCartViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
