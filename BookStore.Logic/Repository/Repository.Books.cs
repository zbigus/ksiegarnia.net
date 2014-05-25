using BookStore.Entities.Models;
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
        public bool AddBook(Book b)
        {
            if (_db.Books.Find(b.Id) != null)
            {
                return false;
            }
            _db.Books.Add(b);
            _db.SaveChanges();
            return true;
        }
    }
}
