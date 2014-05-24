using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string ShopComment { get; set; }
        public OrderStatus Status { get; set; }
    }
}