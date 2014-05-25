using BookStore.Entities.Models;
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
        public OrderStatus GetOrderStatus(int id)
        {
            var order = _db.Orders.FirstOrDefault(s => s.Id == id);
            if (order != null)
            {
                return order.Status;
            }
            throw new NullReferenceException();

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
        public bool AddOrder(Order order)
        {
            if (_db.Orders.Find(order.Id) != null)
            {
                return false;
            }
            _db.Orders.Add(order);
            _db.SaveChanges();
            return true;
        }
    }
}
