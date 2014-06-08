using System.Collections.Generic;
using BookStore.Logic.Interfaces;
using System.Web.Http;
using BookStore.Logic.Models;

namespace BookStore.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IRepository repo) : base(repo) { }

        public List<CategoryModel> Get()
        {
            return Repo.GetCategories();
        }

        [Route("api/Categories/{id}")]
        public CategoryModel Get(int id)
        {
            return Repo.GetCategory(id);
        }

        [HttpPost]
        [Route("api/Categories/Add")]
        public IHttpActionResult AddCategory([FromBody]CategoryModel category)
        {
            if (!Repo.AddCategory(category.Name))
            {
                return Conflict();
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Categories/Update")]
        public IHttpActionResult UpdateCategory([FromBody]CategoryModel category)
        {
            if (!Repo.UpdateCategory(category))
            {
                return Conflict();
            }
            return Ok();
        }
        //do przeniesienia

        [HttpPost]
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

        [HttpPost]
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

        [HttpDelete]
        [Route("api/BookCategories/{bookId}/Delete/{category}")]
        public IHttpActionResult DeleteBookCategories(int category, int bookId)
        {
            Repo.DeleteBookCategory( category,bookId);
            return Ok();
        }

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
