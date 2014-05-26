using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    [DataContract]
    public class BookModel : SimpleBookModel
    {
        //TODO: Dodaæ walidacjê, tylko 13 cyfr
        [DataMember]
        public string Isbn { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public DateTime Year { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<AttachmentModel> Attachments { get; set; }
        [DataMember]
        public List<CategoryModel> Categories { get; set; }

        public BookModel(Book book) : base(book)
        {
            Isbn = book.Isbn;
            Publisher = book.Publisher;
            Year = book.Year;
            Description = book.Description;
        }

        public new static BookModel Create(Book book)
        {
            return new BookModel(book);
        }
    }
}