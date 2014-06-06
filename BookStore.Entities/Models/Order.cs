using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Models
{
    public class Order : ChangeBase
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public string UserId { get; set; }

        public string ShopComment { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}