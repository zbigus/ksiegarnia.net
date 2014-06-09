using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class BookModel
    {
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
        [Required]
        [StringLength(255, ErrorMessage = "{0} nie mo¿e zawieraæ wiêcej ni¿ {1} znaków.")]
        public string Title { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "{0} nie mo¿e zawieraæ wiêcej ni¿ {1} znaków.")]
        public string Author { get; set; }
        public int Price { get; set; }
        [Required]
        [StringLength(13, ErrorMessage = "{0} musi zawieraæ {1} znaków.", MinimumLength = 13)]
        public string Isbn { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "{0} nie mo¿e zawieraæ wiêcej ni¿ {1} znaków.")]
        public string Publisher { get; set; }
        public DateTime Year { get; set; }
        [Required]
        public string Description { get; set; }
        public List<AttachmentModel> Attachments { get; set; }
        public List<CategoryModel> Categories { get; set; }

        public static BookModel Create(Book book)
        {
            return new BookModel(book);
        }
    }
}