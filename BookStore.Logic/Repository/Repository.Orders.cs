using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Helpers;
using BookStore.Entities.Models;
using BookStore.Logic.Extensions;
using BookStore.Logic.Models;

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
            return null; //_db.Orders.Where(s => s.UserId == id);
        }

        public bool GetOrderStatus(int id, out string status)
        {
            Order order = _db.Orders.Find(id);
            if (order == null)
            {
                status = null;
                return false;
            }
            status = order.Status.ToString();
            return true;
        }

        public bool DeleteOrder(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order == null)
            {
                return false;
            }
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return true;
        }

        //To nie ma sensu
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
                Status = OrderStatus.Ordered
            };
            _db.Orders.Add(o);
            _db.SaveChanges();
            id = o.Id;
            return true;
        }


        /// <summary>
        /// Pobiera wszystkie zamówienia z bazy (Admin)
        /// </summary>
        /// <returns>Lista zamówień</returns>
        public List<OrderModel> GetOrders()
        {
            return _db.Orders
                .OrderByDescending(arg => arg.InsertDate)
                .Select(arg => new OrderModel
                {
                    Id = arg.Id,
                    BookTitle = arg.Book.Title,
                    Status = arg.Status,
                    StatusName = arg.Status.GetAttribute<ResxAttribute>().Name
                }).ToList();
        }

        /// <summary>
        /// Pobiera wszystkie zamówienia z bazy (Admin)
        /// </summary>
        /// <param name="status">Status zamówienia</param>
        /// <returns>Lista zamówień</returns>
        public List<OrderModel> GetOrders(OrderStatus status)
        {
            return _db.Orders
                .Where(arg => arg.Status == status)
                .OrderByDescending(arg => arg.InsertDate)
                .Select(arg => new OrderModel
                {
                    Id = arg.Id,
                    BookTitle = arg.Book.Title,
                    Status = arg.Status,
                    StatusName = arg.Status.GetAttribute<ResxAttribute>().Name
                }).ToList();
        }

        /// <summary>
        /// Pobiera wszystkie zamówienia z bazy (Użytkownik)
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <returns>Lista zamówień</returns>
        public List<OrderModel> GetOrders(string userId)
        {
            return _db.Orders
                .Where(arg => arg.UserId == userId)
                .OrderByDescending(arg => arg.InsertDate)
                .Select(arg => new OrderModel
                {
                    Id = arg.Id,
                    BookTitle = arg.Book.Title,
                    Status = arg.Status,
                    StatusName = arg.Status.GetAttribute<ResxAttribute>().Name
                }).ToList();
        }

        /// <summary>
        /// Pobiera wszystkie zamówienia z bazy (Użytkownik)
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <param name="status">Status zamówienia</param>
        /// <returns>Lista zamówień</returns>
        public List<OrderModel> GetOrders(string userId, OrderStatus status)
        {
            return _db.Orders
                .Where(arg => arg.UserId == userId && arg.Status == status)
                .OrderByDescending(arg => arg.InsertDate)
                .Select(arg => new OrderModel
                {
                    Id = arg.Id,
                    BookTitle = arg.Book.Title,
                    Status = arg.Status,
                    StatusName = arg.Status.GetAttribute<ResxAttribute>().Name
                }).ToList();
        }

        /// <summary>
        /// Pobiera zamówienie z bazy
        /// </summary>
        /// <param name="id">Id zamówienia</param>
        /// <returns>Zamówienie</returns>
        public OrderDetailModel GetOrder(int id)
        {
            var order = _db.Orders.Find(id);
            return order == null ? null : OrderDetailModel.Create(order);
        }

        /// <summary>
        /// Dodawanie zamówienia
        /// </summary>
        /// <param name="bookId">Id zamawianej książki</param>
        /// <param name="userId">Id zamawiającego</param>
        /// <returns>Potwierdzenie zamówienia</returns>
        public bool AddOrder(int bookId, string userId)
        {
            //Sprawdzamy czy książka istnieje
            if (_db.Books.Find(bookId) == null)
                return false;
            //Sprawdzamy czy użytkownik istnieje
            if (_db.Users.Find(userId) == null)
                return false;
            var order = new Order {BookId = bookId, UserId = userId, Status = OrderStatus.Ordered};
            _db.Orders.Add(order);
            _db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Zmiana statusu zamówienia
        /// </summary>
        /// <param name="id">Id zamówienia</param>
        /// <param name="newStatus">Nowy status zamówienia</param>
        /// <param name="shopComment">Komentarz sklepu</param>
        /// <returns>Potwierdzenie zmiany statusu</returns>
        public bool UpdateOrderStatus(int id, OrderStatus newStatus, string shopComment = "")
        {
            //Nie można zmienić statusu na zamówiony, do tego służy metoda AddOrder
            if (newStatus == OrderStatus.Ordered)
                return false;
            //Sprawdzamy czy zamówienie istnieje
            var order = _db.Orders.Find(id);
            if (order == null)
                return false;
            order.Status = newStatus;
            order.ShopComment = shopComment;
            _db.SaveChanges();
            return true;
        }
    }
}