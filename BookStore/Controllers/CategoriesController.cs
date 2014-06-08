using System.Collections.Generic;
using System.Web.Http.Results;
using BookStore.Logic.Interfaces;
using System.Web.Http;

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
        public IHttpActionResult PostCategory([FromBody]string name)
        {
            if (!Repo.AddCategory(name))
            {
                return Conflict();
            }
            return Ok();
        }


        [HttpPost]
        [Route("api/BookCategories/Add")]
        public IHttpActionResult PostBookCategories([FromBody]int bookId, [FromBody] List<int> categories)
        {
            Repo.AddBookCategories(bookId,categories);
            return Ok();
        }


        [Route("api/Categories/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (Repo.DeleteCategory(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
