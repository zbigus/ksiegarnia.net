using BookStore.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository 
    {
        public IQueryable<Book> GetAllBooks()
        {
            return _db.Books.AsQueryable();
        }
        public Book GetBookById(int id)
        {
            return _db.Books.FirstOrDefault(s => s.Id == id);
        }
        public bool DeleteBook(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return false;
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }
        public bool AddBook(BookModel b, List<string> category,out int id)
        {
            if (_db.Books.Find(b.Id) != null)
            {
                id = 0;
                return false;
            }
            var book = new Book
            {
                Id=b.Id,
                Author = b.Author,
                Title = b.Title,
                Isbn = b.Isbn,
                Publisher = b.Publisher,
                Year = b.Year,
                Price = b.Price,
                Description = b.Description
            };
            _db.Books.Add(book);
            _db.SaveChanges();

            id = book.Id;
            foreach (var item in category)
            {
                var query = from d in _db.Categories where d.Name == item select d.Id;
                var index = query.ToArray()[0];
                _db.BookCategories.Add(new BookCategory {BookId = book.Id, CategoryId = index});
                _db.SaveChanges();
            }

            return true;
        }
    }
}
