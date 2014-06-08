using System.Collections.Generic;
using System.Web.Http;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;

namespace BookStore.Controllers
{
    public class BooksController : BaseApiController
    {
        public BooksController(IRepository repo) : base(repo) { }
        public List<SimpleBookModel> Get()
        {
            return Repo.GetBooks();
        }
        //[HttpGet]
        //[Authorize]
        [Route("api/Books/{id}")]
        public BookModel Get(int id)
        {
            return Repo.GetBook(id);
        }

        //[Route("api/Books/Initial")]
        //public List<SimpleBookModel> GetInitialData()
        //{
        //    return Repo.GetInitialBooks();
        //}
        //[Authorize]
        [Route("api/Books/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            if (Repo.DeleteBook(id)) {
                return Ok();
            }
            return NotFound();            
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] BookModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Repo.AddBook(book))
            {
                return CreatedAtRoute("DefaultApi", new { }, book);
            }
            return Conflict();
        }
    }
}
