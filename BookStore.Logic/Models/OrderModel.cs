using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public string ShopComment { get; set; }
        public OrderStatus Status { get; set; }
    }
}