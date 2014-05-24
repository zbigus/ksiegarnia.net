using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Repository
{
    public class Repository : IRepository, IDisposable
    {
        private BookStoreContext _db = new BookStoreContext();

        public IQueryable<Book> GetAllBooks() {
            return _db.Books.AsQueryable();
        }
        public Book GetBookByID(int id)
        {
            return _db.Books.FirstOrDefault(s => s.Id == id);
        }
        public bool DeleteBook(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return false;
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }
        public bool AddBook(Book b)
        {
            if (_db.Books.Find(b.Id) != null)
            {
                return false;
            }
            _db.Books.Add(b);
            _db.SaveChanges();
            return true;
        }

        public Attachment GetAttachmentByID(int id)
        {
            return _db.Attachments.Find(id);
        }
        public bool AddAttachment(Attachment a)
        {
            if (_db.Attachments.Find(a.Id) != null)
            {
                return false;
            }
            _db.Attachments.Add(a);
            _db.SaveChanges();
            return true;
        }
        public bool DeleteAttachment(int id)
        {
            var attachment = _db.Attachments.Find(id);
            if (attachment == null)
            {
                return false; 
            }
            _db.Attachments.Remove(attachment);
            _db.SaveChanges();
            return true;
        }
        public IQueryable<Order> GetAllOrders()
        {
            return _db.Orders.AsQueryable();
        }
        public IQueryable<Order> GetOrdersByBookID(int id)
        {
            return _db.Orders.Where(s=> s.BookId == id);
        }
        public IQueryable<Order> GetOrdersByUserID(int id)
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
            if (order == null) {
                return false;
            }
            order.Status = newStatus;
            _db.SaveChanges();
            return true;
        }
        public bool DeleteOrder(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null) {
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
        public IQueryable<User> GetAllUsers()
        {
            return _db.Users.AsQueryable();
        }
        public IQueryable<User> GetUsersByRole(string role)
        {
            return _db.Users.Where(s => s.Role.Name.Equals(role,StringComparison.OrdinalIgnoreCase));
        }
        public bool AddUser(User user)
        {
            if (_db.Users.Find(user.Id) != null)
            {
                return false;
            }
            _db.Users.Add(user);
            _db.SaveChanges();
            return true;
        }
        /*IQueryable<Book> GetBooksByCategorie(Category category) {
            var bookCategories = _db.BookCategories.Where(s=> s.Category == category);
            
        }*/
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
