using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Logic.Models;

namespace BookStore.Logic.RepositoryInterfaces
{
    public interface IBooksRepository
    {

        IQueryable<Book> GetAllBooks();
        Book GetBookById(int id);
        bool DeleteBook(int id);
        bool AddBook(Book b,string category, out int id);
    }
}
