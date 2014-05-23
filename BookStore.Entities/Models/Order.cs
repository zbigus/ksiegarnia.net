using System;

namespace BookStore.Entities.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public string ShopComment { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime? InsertDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
