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

namespace BookStore.SPA.Controllers
{
    public class BooksController : BaseApiController
    {
        public BooksController(IRepository repo) : base(repo) { }
        
        public IHttpActionResult Get()
        {
            var book = Repo.GetBooks();
            return Ok(book);
        }

        //[HttpGet]
        public IHttpActionResult Get(int id)
        {
            var book = Repo.GetBook(id);
            if (book != null)
                return Ok(book);
            return NotFound();
        }

        
        //[Authorize]
        [Route("api/Books/Delete/{id}")]
        [ResponseType(typeof(Book))]
        public IHttpActionResult Delete(int id) {
            if (Repo.DeleteBook(id)) {
                return Ok();
            }
            return NotFound();            
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] object[] data)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/
            var book = JsonConvert.DeserializeObject<BookModel>(data[0].ToString());
            var categories = JsonConvert.DeserializeObject<List<string>>(data[1].ToString());
            int id;
            if (Repo.AddBook(book))
            {
                return Ok();
                //return CreatedAtRoute("DefaultApi", book);
            }
            return Conflict();
        }
    }
}
