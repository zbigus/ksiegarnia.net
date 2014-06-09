using System.Collections.Generic;
using System.Web.Http;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;

namespace BookStore.Controllers
{
    public class BooksController : BaseApiController
    {
        public BooksController(IRepository repo) : base(repo) { }
        /// <summary>
        /// Gets all the books from the bookstore
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        [Route("api/Books/category/{id}")]
        public List<SimpleBookModel> GetBooksByCategory(int id)
        {
            return Repo.GetBooksByCategory(id);
        }

        [Route("api/Books/top")]
        public List<SimpleBookModel> GetTopBooks()
        {
            return Repo.GetTopNewBooks();
        }

        [Route("api/Books/bestsellers")]
        public List<SimpleBookModel> GetBestsellers()
        {
            return Repo.GetTopSaleBooks();
        }

        [HttpGet]
        [Route("api/Books/search/{phrase}")]
        public List<SimpleBookModel> Search(string phrase)
        {
            return Repo.SearchBooks(phrase);
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

        [HttpPost]
        [Route("api/Books/update")]
        public IHttpActionResult UpdateBook([FromBody] BookModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Repo.UpdateBook(book))
            {
                return Ok();
            }
            return Conflict();
        }

    }
}
