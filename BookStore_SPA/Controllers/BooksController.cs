using System.Data.Entity;
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
        public IHttpActionResult Get() {
            return Ok(Repo.GetAllBooks());
        }
        public IHttpActionResult Get(int id) {
            var book = Repo.GetBookByID(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [Route("api/Books/Initial")]
        public IHttpActionResult GetInitialData()
        {
            var initialData = Repo.GetAllBooks().ToList().Select(s => TheModelFactory.CreateInitial(s));
            return Ok(initialData);
        }
        /*public IHttpActionResult Delete(int id) {
            if (Repo.DeleteBook(id)) {
                return Ok();
            }
            return NotFound();            
        }*/
    }
}
