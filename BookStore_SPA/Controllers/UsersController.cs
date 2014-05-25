using System.Linq;
using System.Web.Http;
using BookStore.Logic.RepositoryInterfaces;

namespace BookStore.SPA.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(IRepository repo) : base(repo) { }

        public IHttpActionResult Get() {
            var query = Repo.GetAllUsers();
            if (query == null)
            {
                return NotFound();
            }
            var results = query.ToList().Select(s=> TheModelFactory.Create(s));
            return Ok(results);
        }
        [Route("api/Users/{role}")]
        public IHttpActionResult Get(string role) {
            var users = Repo.GetUsersByRole(role);
            if (users == null)
            {
                return NotFound();
            }
            var result = users.ToList().Select(s => TheModelFactory.Create(s));
            return Ok(result);
        }
    }
}
