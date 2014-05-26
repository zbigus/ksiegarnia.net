using System.Data.Entity;
using BookStore.Entities.Models;
using BookStore.Logic.Models;
using BookStore.Logic.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool AddBook(Book b, string category,out int id)
        {
            if (_db.Books.Find(b.Id) != null)
            {
                id = 0;
                return false;
            }
            _db.Books.Add(b);
            _db.SaveChanges();

            id = b.Id;
            var query = from d in _db.Categories where d.Name == category select d.Id;
            _db.BookCategories.Add(new BookCategory {BookId = b.Id, CategoryId = query.ToArray()[0]});
            _db.SaveChanges();

            return true;
        }
    }
}
