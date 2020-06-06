using BoookStoreDatabase2.DAL.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoookStoreDatabase2.DAL.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNo { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public List<OrderLines> OrderLines { get; set; }
    }
}
