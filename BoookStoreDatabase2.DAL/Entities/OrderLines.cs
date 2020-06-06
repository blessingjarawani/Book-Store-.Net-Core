using BoookStoreDatabase2.DAL.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoookStoreDatabase2.DAL.Entities
{
    public class OrderLines : BaseEntity
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }

    }
}
