using System;
using System.Collections.Generic;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class BookModel
    {
        //TODO: Dodaæ walidacjê, tylko 13 cyfr

        public BookModel()
        {
        }

        public BookModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Description = book.Description;
            Price = book.Price;
            Isbn = book.Isbn;
            Publisher = book.Publisher;
            Year = book.Year;
            Categories = new List<CategoryModel>();
            foreach (BookCategory bookCategory in book.BookCategories)
            {
                Categories.Add(new CategoryModel(bookCategory.Category));
            }
            Attachments = new List<AttachmentModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
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