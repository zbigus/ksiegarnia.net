using System.Linq;
using System.Web.Http;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;

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
            var results = query.ToList().Select(s=>TheModelFactory.Create(s));
            return Ok(results);
        }
        [Route("api/Users/Role/{role}")]
        public IHttpActionResult Get(string role) {
            var users = Repo.GetUsersByRole(role);
            if (users == null)
            {
                return NotFound();
            }
            var result = users.ToList().Select(s => TheModelFactory.Create(s));
            return Ok(result);
        }
        [Route("api/Users/GetID/{login}")]
        public IHttpActionResult GetIDByLogin(string login)
        {
            var users = Repo.GetUsersIDByLogin(login);
            if (users == null)
            {
                return NotFound();
            }
            var result = users.ToList().Select(s => s.Id);
            return Ok(result);
        }
        [Route("api/Users/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (Repo.DeleteUser(id))
            {
                return Ok();
            }
            return NotFound();
        }
        //TODO:Dodac dodawanie uzytkownika - gdzie przeslac haslo? User zamiast UserModel w post
        //TODO:czy haslo osobno przesylamy?
    }
}
