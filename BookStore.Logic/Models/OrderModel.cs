using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Book { get; set; }
        public string User { get; set; }
        public string ShopComment { get; set; }
        public OrderStatus Status { get; set; }
    }
}