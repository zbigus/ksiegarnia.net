namespace BookStore.Entities.Models
{
    public class Order : ChangeBase
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string ShopComment { get; set; }
        public OrderStatus Status { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
