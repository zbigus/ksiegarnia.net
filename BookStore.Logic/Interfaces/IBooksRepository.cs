using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IBooksRepository
    {

        IQueryable<Book> GetAllBooks();
        Book GetBookById(int id);
        bool DeleteBook(int id);
        bool AddBook(BookModel b,List<string> category, out int id);
    }
}
