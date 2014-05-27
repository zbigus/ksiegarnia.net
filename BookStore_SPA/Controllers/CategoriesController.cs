using BookStore.Entities.Models;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.SPA.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IRepository repo) : base(repo) { }

        public IHttpActionResult Get()
        {
            return Ok(Repo.GetAllCategories().ToList().Select(s=>TheModelFactory.Create(s)));
        }

        public IHttpActionResult Post([FromBody] CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id;
            if (Repo.AddCategory(category.Name,out id))
            {
                return CreatedAtRoute("DefaultApi", new { id = id }, category);
            }
            return Conflict();
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
