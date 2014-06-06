using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Models
{
    public class BookCategory
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}