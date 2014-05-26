using System;
using System.Collections.Generic;

namespace BookStore.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
