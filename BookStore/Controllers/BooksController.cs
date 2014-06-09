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
        /// <returns></returns>
        public List<SimpleBookModel> Get()
        {
            return Repo.GetBooks();
        }
        //[HttpGet]
        //[Authorize]
        
        /// <summary>
        /// Get book with specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Books/{id}")]
        public BookModel Get(int id)
        {
            return Repo.GetBook(id);
        }
        /// <summary>
        /// Get books from given category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Books/category/{id}")]
        public List<SimpleBookModel> GetBooksByCategory(int id)
        {
            return Repo.GetBooksByCategory(id);
        }

        /// <summary>
        /// Get top 10 books from bookstore
        /// </summary>
        /// <returns></returns>
        [Route("api/Books/top")]
        public List<SimpleBookModel> GetTopBooks()
        {
            return Repo.GetTopNewBooks();
        }

        /// <summary>
        /// Get 5 bestselling books
        /// </summary>
        /// <returns></returns>
        [Route("api/Books/bestsellers")]
        public List<SimpleBookModel> GetBestsellers()
        {
            return Repo.GetTopSaleBooks();
        }

        /// <summary>
        /// Search for books with given phrase
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete book with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Books/Delete/{id}")]
        public IHttpActionResult Delete(int id) {
            if (Repo.DeleteBook(id)) {
                return Ok();
            }
            return NotFound();            
        }

        /// <summary>
        /// Add new book to database
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update existing book in database
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
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
