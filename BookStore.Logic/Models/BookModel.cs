using System;
using System.Collections.Generic;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class BookModel : SimpleBookModel
    {
        //TODO: Dodaæ walidacjê, tylko 13 cyfr

        protected BookModel()
        {
        }

        public BookModel(Book book) : base(book)
        {
            Isbn = book.Isbn;
            Publisher = book.Publisher;
            Year = book.Year;
            Description = book.Description;
            Categories = new List<CategoryModel>();
            foreach (BookCategory bookCategory in book.BookCategories)
            {
                Categories.Add(new CategoryModel(bookCategory.Category));
            }
            Attachments = new List<AttachmentModel>();
        }

        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public DateTime Year { get; set; }
        public string Description { get; set; }
        public List<AttachmentModel> Attachments { get; set; }
        public List<CategoryModel> Categories { get; set; }

        public void SetAttachments(IEnumerable<Attachment> attachments)
        {
            foreach (Attachment attachment in attachments)
            {
                Attachments.Add(AttachmentModel.Create(attachment));
            }
        }

        public static BookModel Create(Book book)
        {
            return new BookModel(book);
        }

        public static BookModel Create(Book book, IEnumerable<Attachment> attachments)
        {
            var result = new BookModel(book);
            result.SetAttachments(attachments);
            return result;
        }
    }
}