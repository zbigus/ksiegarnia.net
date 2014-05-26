using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IBooksRepository
    {
        IEnumerable<SimpleBookModel> GetBooks();
        IEnumerable<SimpleBookModel> GetBooks(int categoryId);
        BookModel GetBook(int id);
        bool DeleteBook(int id);
        bool AddBook(BookModel book);
    }
}
