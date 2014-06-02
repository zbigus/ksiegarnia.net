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
        public List<AttachmentModel> AttachmentsContent { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}