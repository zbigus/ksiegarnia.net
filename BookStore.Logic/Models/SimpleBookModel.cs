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
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public AttachmentModel Attachment { get; set; }

        public static SimpleBookModel Create(Book book)
        {
            return new SimpleBookModel(book);
        }
    }
}