using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}