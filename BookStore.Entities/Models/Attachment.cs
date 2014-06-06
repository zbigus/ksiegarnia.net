using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Models
{
    public class Attachment
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public virtual Book Book { get; set; }
    }
}