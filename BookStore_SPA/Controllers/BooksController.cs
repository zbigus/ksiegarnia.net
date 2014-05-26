using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BookStore.Entities.Models;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;

namespace BookStore.SPA.Controllers
{
    public class BooksController : BaseApiController
    {
        public BooksController(IRepository repo) : base(repo) { }

        [ResponseType(typeof(List<BookModel>))]
        public IHttpActionResult Get()
        {
            var book = Repo.GetBooks();
            return Ok(book);
        }

        [ResponseType(typeof(List<BookModel>))]
        public IHttpActionResult GetBooks(int categoryId)
        {
            var book = Repo.GetBooks(categoryId);
            return Ok(book);
        }

        [ResponseType(typeof(BookModel))]
        public IHttpActionResult Get(int id)
        {
            var book = Repo.GetBook(id);
            if (book != null)
                return Ok(book);
            return NotFound();
        }

        [Route("api/Books/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            if (Repo.DeleteBook(id)) {
                return Ok();
            }
            return NotFound();            
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] BookModel data)
        {
            if (Repo.AddBook(data))
            {
                return Ok();
            }
            return Conflict();
        }
    }
}
