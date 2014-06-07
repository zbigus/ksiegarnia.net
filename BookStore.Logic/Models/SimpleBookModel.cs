using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class SimpleBookModel
    {
        protected SimpleBookModel()
        {
        }

        public SimpleBookModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Price = book.Price;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}