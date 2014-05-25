using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.RepositoryInterfaces
{
    public interface IOrdersRepository
    {
        IQueryable<Order> GetAllOrders();
        IQueryable<Order> GetOrdersByBookId(int id);
        IQueryable<Order> GetOrdersByUserId(int id);
        OrderStatus GetOrderStatus(int id);
        bool UpdateOrderStatus(int id, OrderStatus newStatus);
        bool DeleteOrder(int id);
        bool AddOrder(Order order);
    }
}
