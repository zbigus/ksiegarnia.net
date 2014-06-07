using System.Collections.Generic;
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
        bool DeleteOrder(int id);
        bool AddOrder(OrderModel order, out int id);

        //Motody do wyświetlania zamówień
        List<OrderModel> GetOrders();
        List<OrderModel> GetOrders(OrderStatus status);
        List<OrderModel> GetOrders(string userId);
        List<OrderModel> GetOrders(string userId, OrderStatus status);
        OrderDetailModel GetOrder(int id);
        //Metody do dodawania zmiany statusu
        bool AddOrder(int bookId, string userId);
        bool UpdateOrderStatus(int id, OrderStatus newStatus, string shopComment = "");

    }
}