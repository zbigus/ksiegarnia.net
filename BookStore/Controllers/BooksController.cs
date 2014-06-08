using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BookStore.Entities.Models;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookStore.Controllers
{
    public class BooksController : BaseApiController
    {
        public BooksController(IRepository repo) : base(repo) { }
        public List<SimpleBookModel> Get()
        {
            return Repo.GetAllBooks();
        }
        //[HttpGet]
        //[Authorize]
        [Route("api/Books/{id}")]
        public BookModel Get(int id)
        {
            return Repo.GetBook(id);
        }

        [Route("api/Books/Initial")]
        public List<SimpleBookModel> GetInitialData()
        {
            return Repo.GetInitialBooks();
        }
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
            int id;
            if (Repo.AddBook(book,out id))
            {
                return CreatedAtRoute("DefaultApi", new { id = id }, book);
            }
            return Conflict();
        }
    }
}
