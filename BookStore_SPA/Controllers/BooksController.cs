using BookStore.Entities.Models;
using BookStore.Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore_SPA.Controllers
{
    public class BooksController : BaseApiController
    {
        public BooksController(IRepository repo) : base(repo) { }
        public IQueryable<Book> Get() {
            return _repo.GetAllBooks();
        }
        public Book Get(int id) {
            return _repo.GetBookByID(id);
        }
    }
}
