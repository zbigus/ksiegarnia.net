using System.Collections.Generic;
using System.Web.Http;
using BookStore.Logic.Interfaces;
using BookStore.Entities.Models;
using BookStore.Logic.Models;
using Microsoft.AspNet.Identity;

namespace BookStore.Controllers
{
    /// <summary>
    /// Controller responsible for managing bookstore orders
    /// </summary>
    public class OrdersController : BaseApiController
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="repo">Interfejs repozytorium</param>
        public OrdersController(IRepository repo) : base(repo)
        {
        }

        /// <summary>
        /// Get all orders from database
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        public List<OrderModel> Get()
        {
            return Repo.GetOrders();
        }

        /// <summary>
        /// Get order details from order with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        public OrderDetailModel Get(int id)
        {
            return Repo.GetOrder(id);
        }

        /// <summary>
        /// Get order details for user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Orders/user/detail/{id}")]
        [Authorize]
        public OrderDetailModel GetForUser(int id)
        {
            var order = Repo.GetOrder(id);
            if (order != null)
            {
                //sprawdzenie czy zamówienie jest przypisane do tego usera
                var user = UserManager.FindById(User.Identity.GetUserId());
                if (order.UserName != user.UserName)
                    order = null;
            }
            return order;
        }

        /// <summary>
        /// get all orders with given status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [Authorize(Roles = Role.Admin)]
        [Route("api/Orders/status/{status}")]
        public List<OrderModel> GetOrdersWithStatus(OrderStatus status)
        {
            return Repo.GetOrders(status);
        }

        /// <summary>
        /// Get all orders for logged in user
        /// </summary>
        /// <returns></returns>
        [Route("api/Orders/user")]
        [Authorize]
        public List<OrderModel> GetOrdersForUser()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var id = user.Id;
            return Repo.GetOrders(id);
        }

        /// <summary>
        /// Get all orders for logged in user with given status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [Route("api/Orders/user/{status}")]
        [Authorize]
        public List<OrderModel> GetOrdersForUserWithStatus(OrderStatus status)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var id = user.Id;
            return Repo.GetOrders(id,status);
        }

        /// <summary>
        /// Order book with given bookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/orders/orderbook/{bookId}")]
        //[Authorize]
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

        /// <summary>
        /// Drop order with given id (as Admin)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Cancel order (as User)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Execute order (set OrderStatus for order with given id to executed)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update OrderStatus for given order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles=Role.Admin)]
        [Route("api/orders/update")]
        public IHttpActionResult UpdateOrderStatus([FromBody] OrderModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Repo.UpdateOrderStatus(order.Id, order.Status))
            {
                return Ok();
            }
            return Conflict();
        }

    }
}
