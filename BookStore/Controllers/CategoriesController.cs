using System.Collections.Generic;
using System.Web.Http.Results;
using BookStore.Entities.Models;
using BookStore.Logic.Interfaces;
using System.Web.Http;
using BookStore.Logic.Models;
using Newtonsoft.Json;

namespace BookStore.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IRepository repo) : base(repo) { }

        public IHttpActionResult Get()
        {
            return Ok(Repo.GetCategories());
        }

        [Route("api/Categories/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(Repo.GetCategory(id));
        }

        [HttpPost]
        [Route("api/Categories/Add")]
        public IHttpActionResult PostCategory([FromBody]CategoryModel category)
        {
            if (!Repo.AddCategory(category.Name))
            {
                return Conflict();
            }
            return Ok();
        }


        [HttpPost]
        [Route("api/BookCategories/{bookId}/Add")]
        public IHttpActionResult PostBookCategories([FromBody] List<CategoryModel> categories,int bookId)
        {
            var categoriesIds = new List<int>();
            foreach (var item in categories)
            {
                categoriesIds.Add(item.Id);
            }
            Repo.AddBookCategories(bookId,categoriesIds);
            return Ok();
        }

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
