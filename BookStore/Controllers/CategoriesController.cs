using BookStore.Logic.Interfaces;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IRepository repo) : base(repo) { }
        
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
