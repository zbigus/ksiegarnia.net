using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BookStore.Entities.Models;
using BookStore.Logic.RepositoryInterfaces;

namespace BookStore.SPA.Controllers
{
    public class BooksController : BaseApiController
    {
        public BooksController(IRepository repo) : base(repo) { }
        public IHttpActionResult Get() {
            return Ok(Repo.GetAllBooks().ToList().Select(s=> TheModelFactory.Create(s)));
        }
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
            var initialData = Repo.GetAllBooks().ToList().Select(s => TheModelFactory.CreateInitial(s));
            return Ok(initialData);
        }
        //[Authorize]
        [ResponseType(typeof(Book))]
        public IHttpActionResult Delete(int id) {
            if (Repo.DeleteBook(id)) {
                return Ok();
            }
            return NotFound();            
        }

        public IHttpActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Repo.AddBook(book))
            {
                return CreatedAtRoute("DefaultApi", new { id = book.Id }, TheModelFactory.Create(book));
            }
            return Conflict();
        }
    }
}
