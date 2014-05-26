using BookStore.Entities.Models;
using BookStore.Logic.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public IEnumerable<OrderModel> GetOrders()
        {
            return _db.Orders.ToList().Select(OrderModel.Create);
        }

        public IEnumerable<OrderModel> GetOrders(int userId)
        {
            return _db.Orders.Where(ord => ord.UserId == userId).ToList().Select(OrderModel.Create);
        }

        public IEnumerable<OrderModel> GetOrdersByBookId(int bookId)
        {
            return _db.Orders.Where(ord => ord.BookId == bookId).ToList().Select(OrderModel.Create);
        }

        public bool AddOrder(OrderModel order)
        {
            if (_db.Orders.Find(order.Id) != null)
                return false;
            _db.Orders.Add(new Order
            {
                Id = order.Id,
                BookId = order.BookId,
                UserId = order.UserId,
                Status = OrderStatus.Ordered
            });
            _db.SaveChanges();
            return true;
        }

        public bool CancelOrder(int orderId, string comment)
        {
            var order = _db.Orders.Find(orderId);
            if (order == null)
                return false;
            order.Status = OrderStatus.Canceled;
            order.ShopComment = comment;
            _db.SaveChanges();
            return true;
        }

        public bool ExecuteOrder(int orderId)
        {
            var order = _db.Orders.Find(orderId);
            if (order == null)
                return false;
            order.Status = OrderStatus.Executed;
            _db.SaveChanges();
            return true;
        }

        public bool AcceptOrder(int orderId)
        {
            var order = _db.Orders.Find(orderId);
            if (order == null)
                return false;
            order.Status = OrderStatus.Ready;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteOrder(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
                return false;
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return true;
        }
    }
}
