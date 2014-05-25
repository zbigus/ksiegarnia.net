using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.RepositoryInterfaces
{
    public partial interface IRepository
    {

        IQueryable<Book> GetAllBooks();
        Book GetBookById(int id);
        bool DeleteBook(int id);
        bool AddBook(Book b);
    }
}
