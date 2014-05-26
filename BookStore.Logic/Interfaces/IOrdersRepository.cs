using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IOrdersRepository
    {
        IEnumerable<OrderModel> GetOrders();
        IEnumerable<OrderModel> GetOrders(int userId); 
        IEnumerable<OrderModel> GetOrdersByBookId(int bookId);
        bool DeleteOrder(int orderId);
        bool AddOrder(OrderModel order);
        bool CancelOrder(int orderId, string comment);
        bool ExecuteOrder(int orderId);
        bool AcceptOrder(int orderId);
    }
}
