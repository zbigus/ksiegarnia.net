using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Logic.Interfaces;
using BookStore.Entities.Models;
using BookStore.Logic.Models;
using Microsoft.AspNet.Identity;

namespace BookStore.Controllers
{
    public class OrdersController : BaseApiController
    {
        public OrdersController(IRepository repo) : base(repo)
        {
        }

        [Authorize(Roles = Role.Admin)]
        public List<OrderModel> Get()
        {
            return Repo.GetOrders();
        }

        [Authorize(Roles = Role.Admin)]
        public OrderDetailModel Get(int id)
        {
            return Repo.GetOrder(id);
        }

        [Route("api/Orders/user/detail/{id}")]
        [Authorize]
        public OrderDetailModel GetForUser(int id)
        {
            var order = Repo.GetOrder(id);
            if (order != null)
            {
                //sprawdzenie czy zamówienie jest przypisane do tego usera
                var user = UserManager.FindById(User.Identity.GetUserId());
                //TODO: można by był tu zwrócić not autorize
                if (order.UserName != user.UserName)
                    order = null;
            }
            return order;
        }

        //get all orders with OrderStatus = status
        [Authorize(Roles = Role.Admin)]
        [Route("api/Orders/status/{status}")]
        public List<OrderModel> GetOrdersWithStatus(OrderStatus status)
        {
            return Repo.GetOrders(status);
        }

        [Route("api/Orders/user")]
        [Authorize]
        public List<OrderModel> GetOrdersForUser()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var id = user.Id;
            return Repo.GetOrders(id);
        }

        [Route("api/Orders/user/{status}")]
        [Authorize]
        public List<OrderModel> GetOrdersForUserWithStatus(OrderStatus status)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var id = user.Id;
            return Repo.GetOrders(id,status);
        }

        [HttpPost]
        [Route("api/orders/orderbook/{bookId}")]
        [Authorize]
        public IHttpActionResult Post(int bookId)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var userId = user.Id;
            if (Repo.AddOrder(bookId, userId))
            {
                return Ok();
            }
            return Conflict();
        }

        [HttpPost]
        [Authorize(Roles=Role.Admin)]
        [Route("api/orders/drop/{id}")]
        public IHttpActionResult DropOrderAsAdmin(int id)
        {
            if (Repo.UpdateOrderStatus(id, OrderStatus.Canceled,"dropped by admin"))
            {
                return Ok();
            }
            return Conflict();
        }

        [HttpPost]
        [Authorize(Roles = Role.User)]
        [Route("api/orders/drop/{id}")]
        public IHttpActionResult DropOrderAsUser(int id)
        {
            if (Repo.UpdateOrderStatus(id, OrderStatus.Canceled, "dropped by user"))
            {
                return Ok();
            }
            return Conflict();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        [Route("api/orders/execute/{id}")]
        public IHttpActionResult ExecuteOrder(int id)
        {
            if (Repo.UpdateOrderStatus(id, OrderStatus.Executed, "executed"))
            {
                return Ok();
            }
            return Conflict();
        }

        [HttpPost]
        [Authorize(Roles=Role.Admin)]
        [Route("api/orders/update")]
        public IHttpActionResult UpdateOrderStatus([FromBody] OrderModel order)
        {
            if (Repo.UpdateOrderStatus(order.Id, order.Status))
            {
                return Ok();
            }
            return Conflict();
        }

    }
}
