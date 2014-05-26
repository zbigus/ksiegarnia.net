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
        public IHttpActionResult Get() {
            return Ok(Repo.GetAllBooks().ToList().Select(s=> TheModelFactory.Create(s)));
        }
        //[HttpGet]
        public IHttpActionResult Get(int id) {
            var book = Repo.GetBookById(id);
            if (book != null)
            {
                var result = TheModelFactory.Create(book);
                return Ok(result);
            }
            return NotFound();
        }

        [Route("api/Books/Initial")]
        public IHttpActionResult GetInitialData()
        {
            var initialData = Repo.GetAllBooks().ToList().Select(s=>TheModelFactory.Create(s));
            return Ok(initialData);
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
        //[Route("api/Books/{category}")]
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
            if (Repo.AddBook(book,categories,out id))
            {
                //return CreatedAtRoute("DefaultApi", new { id = id }, book);
                return Ok();
            }
            return Conflict();
        }
    }
}
