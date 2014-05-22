using System;
using System.Collections.Generic;

namespace BookStore.Entities.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public string ShopComment { get; set; }
        public OrderStatus Status { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
