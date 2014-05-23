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
        private BookStoreContext db = new BookStoreContext();

        public IQueryable<Book> GetAllBooks() {
            return db.Books.AsQueryable();
        }
        public Book GetBookByID(int id)
        {
            return db.Books.FirstOrDefault(s => s.ID == id);
        }
        public bool DeleteBook(int id)
        {
            var book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool AddBook(Book b)
        {
            if (db.Books.Find(b.ID) == null)
            {
                db.Books.Add(b);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Attachment GetAttachmentByID(int id)
        {
            return db.Attachments.Find(id);
        }
        public bool AddAttachment(Attachment a)
        {
            if (db.Attachments.Find(a.ID) == null)
            {
                db.Attachments.Add(a);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteAttachment(int id)
        {
            var attachment = db.Attachments.Find(id);
            if (attachment != null)
            {
                db.Attachments.Remove(attachment);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public IQueryable<Order> GetAllOrders()
        {
            return db.Orders.AsQueryable();
        }
        public IQueryable<Order> GetOrdersByBookID(int id)
        {
            return db.Orders.Where(s=> s.BookID == id);
        }
        public IQueryable<Order> GetOrdersByUserID(int id)
        {
            return db.Orders.Where(s => s.UserID == id);
        }
        public OrderStatus GetOrderStatus(int id)
        {
            return db.Orders.FirstOrDefault(s=> s.ID == id).Status;
        }
        public bool UpdateOrderStatus(int id, OrderStatus newStatus)
        {
            var order = db.Orders.Find(id);
            if (order != null) {
                order.Status = newStatus;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteOrder(int id)
        {
            var order = db.Orders.Find(id);
            if (order != null) {
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool AddOrder(Order order)
        {
            if (db.Orders.Find(order.ID) == null)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public IQueryable<User> GetAllUsers()
        {
            return db.Users.AsQueryable();
        }
        public IQueryable<User> GetUsersByRole(Role role)
        {
            return db.Users.Where(s => s.Role == role);
        }
        public bool AddUser(User user)
        {
            if (db.Users.Find(user.ID) == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        /*IQueryable<Book> GetBooksByCategorie(Category category) {
            var bookCategories = db.BookCategories.Where(s=> s.Category == category);
            
        }*/
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
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
