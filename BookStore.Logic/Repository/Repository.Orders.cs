using BookStore.Entities.Models;
using BookStore.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Repository
{
    public partial class Repository 
    {
        public IQueryable<Order> GetAllOrders()
        {
            return _db.Orders.AsQueryable();
        }
        public IQueryable<Order> GetOrdersByBookId(int id)
        {
            return _db.Orders.Where(s => s.BookId == id);
        }
        public IQueryable<Order> GetOrdersByUserId(int id)
        {
            return _db.Orders.Where(s => s.UserId == id);
        }

        public bool GetOrderStatus(int id, out string status)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                status = null;
                return false;
            }
            status = order.Status.ToString();
            return true;
        }

        public bool UpdateOrderStatus(int id, OrderStatus newStatus)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return false;
            }
            order.Status = newStatus;
            _db.SaveChanges();
            return true;
        }
        public bool DeleteOrder(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return false;
            }
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return true;
        }
        public bool AddOrder(OrderModel order, out int id)
        {
            if (_db.Orders.Find(order.Id) != null)
            {
                id = 0;
                return false;
            }
            var o = new Order
            {
                Id = order.Id,
                BookId = order.BookID,
                UserId = order.UserID,
                InsertDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                ShopComment = order.ShopComment,
                Status = order.Status
            };
            _db.Orders.Add(o);
            _db.SaveChanges();
            id = o.Id;
            return true;
        }
    }
}
