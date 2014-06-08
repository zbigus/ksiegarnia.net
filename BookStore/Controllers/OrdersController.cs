using System.Web.Http;
using BookStore.Logic.Interfaces;
using BookStore.Entities.Models;
using Microsoft.AspNet.Identity;

namespace BookStore.Controllers
{

    public class OrdersController : BaseApiController
    {
        public OrdersController(IRepository repo) : base(repo)
        {
        }
        [Authorize(Users="Admin")]
        public IHttpActionResult Get()
        {
            return Ok(Repo.GetOrders());
        }

        [Authorize(Users = "Admin")]
        public IHttpActionResult Get(int id)
        {
            return Ok(Repo.GetOrder(id));
        }

        //get all orders with OrderStatus = status
        [Authorize(Users = "Admin")]
        [Route("api/Orders/status/{status}")]
        public IHttpActionResult GetOrdersWithStatus(OrderStatus status)
        {
            return Ok(Repo.GetOrders(status));
        }

        [Route("api/Orders/user")]
        public IHttpActionResult GetOrdersForUser()
        {
            var id = User.Identity.GetUserId();
            return Ok(Repo.GetOrders(id));
        }

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
    }
}
