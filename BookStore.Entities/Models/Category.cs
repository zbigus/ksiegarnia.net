using System;
using System.Collections.Generic;

namespace BookStore.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        
        public virtual ICollection<BookCategory> BookCategories { get; set; }

        public static List<string> DefaultCategories = new List<string>
        {
            "Dramat",
            "Akcja",
            "Science Fiction",
            "Fantastyka",
            "Horror",
            "Historyczny",
            "Poemat"
        }; 
    }
}
