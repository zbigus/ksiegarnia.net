using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IBooksRepository
    {
        List<BookModel> GetAllBooks();
        List<SimpleBookModel> GetInitialBooks();
        BookModel GetBookById(int id);
        bool AddBook(BookModel b, out int id);

        BookModel GetBook(int id);
        List<SimpleBookModel> GetBooks();
        List<SimpleBookModel> GetBooksByCategory(int categoryId);
        BookModel AddBook(BookModel book);
        bool UpdateBook(BookModel book);
        bool DeleteBook(int id);
    }
}