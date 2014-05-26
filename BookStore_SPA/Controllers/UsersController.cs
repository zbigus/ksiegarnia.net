using System.Linq;
using System.Web.Http;
using BookStore.Logic.Interfaces;

namespace BookStore.SPA.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(IRepository repo) : base(repo) { }

        public IHttpActionResult Get() {
            var query = Repo.GetUsers();
            if (query == null)
            {
                return NotFound();
            }
            var results = query;
            return Ok(results);
        }
        
        [Route("api/Users/GetID/{login}")]
        public IHttpActionResult GetIdByLogin(string login)
        {
            return Ok();
            //var users = Repo.GetUsersIDByLogin(login);
            //if (users == null)
            //{
            //    return NotFound();
            //}
            //var result = users.ToList().Select(s => s.Id);
            //return Ok(result);
        }
    }
}
