using System.Linq;
using BookStore.Entities.Models;

namespace BookStore.Logic.Interfaces
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
