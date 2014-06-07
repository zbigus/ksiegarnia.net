using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string Status { get; set; }
    }
}