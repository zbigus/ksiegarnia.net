using System.Linq;
using BookStore.Entities.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IBooksRepository
    {

        IQueryable<Book> GetAllBooks();
        Book GetBookById(int id);
        bool DeleteBook(int id);
        bool AddBook(Book b);
    }
}
