using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;
using BookStore.Entities.Models;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using BookStore.Logic.Managers;

namespace BookStore.Controllers
{
    public class OrdersController : BaseApiController
    {
        public OrdersController(IRepository repo) : base(repo)
        {
        }

        [Authorize(Roles = Role.Admin)]

        public IHttpActionResult Get()
        {
            return Ok(Repo.GetOrders());
        }

        //[Authorize(Roles = Role.Admin)]

        public IHttpActionResult Get(int id)
        {
            return Ok(Repo.GetOrder(id));
        }

        //get all orders with OrderStatus = status
        //[Authorize(Roles = Role.Admin)]
        [Route("api/Orders/status/{status}")]

        public IHttpActionResult GetOrdersWithStatus(OrderStatus status)
        {
            return Ok(Repo.GetOrders(status));
        }

        /*[Route("api/Orders/user")]
        public IHttpActionResult GetOrdersForUser()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return Ok(Repo.GetOrders(id));
        }*/

        [Route("api/Orders/user/{status}")]
        public IHttpActionResult GetOrdersForUserWithStatus(OrderStatus status)
        {
            
            var id = User.Identity.GetUserId();
            return Ok(Repo.GetOrders(id,status));
        }

        [HttpPost]
        [Route("api/orders/orderbook/{id}")]
        public IHttpActionResult Post(int bookId)
        {
            int id;
            var userId = User.Identity.GetUserId();
            if (Repo.AddOrder(bookId, userId))
            {
                return Ok();
            }
            return Conflict();
        }
        //[Authorize(Roles = Role.Admin)]
        [Route("api/Orders/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (Repo.DeleteOrder(id))
            {
                return Ok();
            }
            return NotFound();
        }

        //get status for order with orderId == id

        [Route("api/Orders/{id}/status")]
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
