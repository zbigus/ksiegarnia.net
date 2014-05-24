using System;

namespace BookStore.Logic.Models
{
    public class BookModel:SampleBookModel
    {
        //TODO: Dodaæ walidacjê, tylko 13 cyfr
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public DateTime Year { get; set; }
        public string Description { get; set; }
    }
}