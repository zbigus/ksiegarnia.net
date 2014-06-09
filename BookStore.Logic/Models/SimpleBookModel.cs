using System.ComponentModel.DataAnnotations;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class SimpleBookModel
    {
        public SimpleBookModel()
        {
        }

        public SimpleBookModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Price = book.Price;
            Description = book.Description;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "{0} nie może zawierać więcej niż {1} znaków.")]
        public string Title { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "{0} nie może zawierać więcej niż {1} znaków.")]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public int Price { get; set; }
        public AttachmentModel Attachment { get; set; }

        public static SimpleBookModel Create(Book book)
        {
            return new SimpleBookModel(book);
        }
    }
}