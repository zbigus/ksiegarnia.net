using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IOrdersRepository
    {
        IQueryable<Order> GetAllOrders();
        IQueryable<Order> GetOrdersByBookId(int id);
        IQueryable<Order> GetOrdersByUserId(int id);
        bool GetOrderStatus(int id, out string status);
        bool UpdateOrderStatus(int id, OrderStatus newStatus);
        bool DeleteOrder(int id);
        bool AddOrder(OrderModel order, out int id);
    }
}