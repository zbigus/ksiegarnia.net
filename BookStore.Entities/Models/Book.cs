using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Models
{
    public class Book : ChangeBase
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Author { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        public string Isbn { get; set; }

        [Required]
        [MaxLength(255)]
        public string Publisher { get; set; }

        public DateTime Year { get; set; }
        public int Price { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}