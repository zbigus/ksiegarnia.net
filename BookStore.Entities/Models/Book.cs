using System;
using System.Collections.Generic;

namespace BookStore.Entities.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        //TODO: Dodać walidację, tylko 13 cyfr
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public DateTime Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
