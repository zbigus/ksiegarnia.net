using System.Collections.Generic;
using BookStore.Entities.Models;
using BookStore.Logic.Interfaces;
using System.Web.Http;
using BookStore.Logic.Models;

namespace BookStore.Controllers
{
    /// <summary>
    /// Controller responsible for managing book categories
    /// </summary>
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IRepository repo) : base(repo) { }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> Get()
        {
            return Repo.GetCategories();
        }

        /// <summary>
        /// Get category with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Categories/{id}")]
        public CategoryModel Get(int id)
        {
            return Repo.GetCategory(id);
        }

        /// <summary>
        /// Add new category to database
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles=Role.Admin)]
        [Route("api/Categories/Add")]
        public IHttpActionResult AddCategory([FromBody]CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!Repo.AddCategory(category.Name))
            {
                return Conflict();
            }
            return Ok();
        }

        /// <summary>
        /// Update existing category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        [Route("api/Categories/Update")]
        public IHttpActionResult UpdateCategory([FromBody]CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!Repo.UpdateCategory(category))
            {
                return Conflict();
            }
            return Ok();
        }
        //do przeniesienia

        /// <summary>
        /// Add book with given id to categories
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        [Route("api/BookCategories/{bookId}/Add")]
        public IHttpActionResult AddBookCategories([FromBody] List<CategoryModel> categories,int bookId)
        {
            var categoriesIds = new List<int>();
            foreach (var item in categories)
            {
                categoriesIds.Add(item.Id);
            }
            Repo.AddBookCategories(bookId,categoriesIds);
            return Ok();
        }

        /// <summary>
        /// Update categories for given book
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        [Route("api/BookCategories/{bookId}/Update")]
        public IHttpActionResult UpdateBookCategories([FromBody] List<CategoryModel> categories, int bookId)
        {
            var categoriesIds = new List<int>();
            foreach (var item in categories)
            {
                categoriesIds.Add(item.Id);
            }
            Repo.AddDeleteBookCatedories(bookId, categoriesIds);
            return Ok();
        }

        //do przeniesienia
        /// <summary>
        /// Delete book from category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = Role.Admin)]
        [Route("api/BookCategories/{bookId}/Delete/{category}")]
        public IHttpActionResult DeleteBookCategories(int category, int bookId)
        {
            Repo.DeleteBookCategory( category,bookId);
            return Ok();
        }
        /// <summary>
        /// Delete category with given id from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = Role.Admin)]
        [Route("api/Categories/Delete/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            if (Repo.DeleteCategory(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
