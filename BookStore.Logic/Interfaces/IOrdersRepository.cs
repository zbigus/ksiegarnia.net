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
        /// <summary>
        /// Pobiera wszystkie zamówienia z bazy posortowane po dacie wstawienia desc (Admin)
        /// </summary>
        /// <returns>Lista zamówień</returns>
        List<OrderModel> GetOrders();

        /// <summary>
        /// Pobiera wszystkie zamówienia z bazy posortowane po dacie wstawienia desc (Admin)
        /// </summary>
        /// <param name="status">Status zamówienia</param>
        /// <returns>Lista zamówień</returns>
        List<OrderModel> GetOrders(OrderStatus status);

        /// <summary>
        /// Pobiera wszystkie zamówienia z bazy posortowane po dacie wstawienia desc (Użytkownik)
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <returns>Lista zamówień</returns>
        List<OrderModel> GetOrders(string userId);

        /// <summary>
        /// Pobiera wszystkie zamówienia z bazy posortowane po dacie wstawienia desc (Użytkownik)
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <param name="status">Status zamówienia</param>
        /// <returns>Lista zamówień</returns>
        List<OrderModel> GetOrders(string userId, OrderStatus status);

        /// <summary>
        /// Pobiera zamówienie z bazy
        /// </summary>
        /// <param name="id">Id zamówienia</param>
        /// <returns>Zamówienie</returns>
        OrderDetailModel GetOrder(int id);

        //Metody do dodawania zmiany statusu
        /// <summary>
        /// Dodawanie zamówienia
        /// </summary>
        /// <param name="bookId">Id zamawianej książki</param>
        /// <param name="userId">Id zamawiającego</param>
        /// <returns>Potwierdzenie zamówienia</returns>
        bool AddOrder(int bookId, string userId);

        /// <summary>
        /// Zmiana statusu zamówienia
        /// </summary>
        /// <param name="id">Id zamówienia</param>
        /// <param name="newStatus">Nowy status zamówienia</param>
        /// <param name="shopComment">Komentarz sklepu</param>
        /// <returns>Potwierdzenie zmiany statusu</returns>
        bool UpdateOrderStatus(int id, OrderStatus newStatus, string shopComment = "");

        /// <summary>
        /// Sprawdza czy dane zamówienie znajduje się w bazie
        /// </summary>
        /// <param name="id">Id zamówienia</param>
        /// <returns>Wynik sprawdzenia</returns>
        bool OrderExists(int id);
    }
}