using System;
using System.Collections.Generic;

namespace BookStore.Logic.Models
{
    public class BookModel : SimpleBookModel
    {
        //TODO: Doda� walidacj�, tylko 13 cyfr
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public DateTime Year { get; set; }
        public string Description { get; set; }
        //TODO: Zamieni� na list�. Ksi��ka mo�e mie� par� za��cznik�w
        //public List<byte[]> AttachmentsContent { get; set; }
        //TODO: Zamieni� na list�. Ksi��ka mo�e mie� par� kategorii
        //public List<string> Categories { get; set; }

    }
}