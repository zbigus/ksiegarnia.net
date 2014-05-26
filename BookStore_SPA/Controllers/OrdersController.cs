using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;
using BookStore.Entities.Models;
using System.Web.Http.Description;

namespace BookStore.SPA.Controllers
{
    public class OrdersController : BaseApiController
    {
        public OrdersController(IRepository repo) : base(repo)
        {
        }
        public IHttpActionResult Get()
        {
            return Ok(Repo.GetAllOrders().ToList().Select(s => TheModelFactory.Create(s)));
        }

        public IHttpActionResult Post([FromBody] OrderModel o)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id;
            if (Repo.AddOrder(o, out id))
            {
                return CreatedAtRoute("DefaultApi", new { id = id }, o);
            }
            return Conflict();
        }
        [Route("api/Orders/Delete/{id}")]
        [ResponseType(typeof(Order))]
        public IHttpActionResult Delete(int id)
        {
            if (Repo.DeleteOrder(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [Route("api/Orders/Status/{id}")]
        public IHttpActionResult GetOrderStatus(int id)
        {
            string stats;
            if (Repo.GetOrderStatus(id,out stats))
            {
                return Ok(stats);
            }
            return NotFound();
        }
    }
}
