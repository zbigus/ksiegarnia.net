using System.Data.Entity;
using BookStore.Logic.Models;
using BookStore.Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore_SPA.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(IRepository repo) : base(repo) { }

        public IHttpActionResult Get() {
            var query = Repo.GetAllUsers();
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
