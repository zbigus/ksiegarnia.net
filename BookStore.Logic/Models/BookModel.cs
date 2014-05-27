using System;
using System.Collections.Generic;

namespace BookStore.Logic.Models
{
    public class BookModel : SimpleBookModel
    {
        //TODO: Dodaæ walidacjê, tylko 13 cyfr
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public DateTime Year { get; set; }
        public string Description { get; set; }
        //TODO: Zamieniæ na listê. Ksi¹¿ka mo¿e mieæ parê za³¹czników
        //public List<byte[]> AttachmentsContent { get; set; }
        //TODO: Zamieniæ na listê. Ksi¹¿ka mo¿e mieæ parê kategorii
        //public List<string> Categories { get; set; }

    }
}