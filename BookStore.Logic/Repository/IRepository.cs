using System;
using BookStore.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Repository
{
    public interface IRepository {
        
        /// <summary>
        /// Book related methods 
        /// </summary>
        
        IQueryable<Book> GetAllBooks();
        Book GetBookByID(int id);
        bool DeleteBook(int id);
        bool AddBook(Book b);

        ///<summary>
        ///Attachment related methods
        ///</summary>

        Attachment GetAttachmentByID(int id);
        bool AddAttachment(Attachment a);
        bool DeleteAttachment(int id);

        ///<summary>
        ///Order related methods
        ///</summary>

        IQueryable<Order> GetAllOrders();
        IQueryable<Order> GetOrdersByBookID(int id);
        IQueryable<Order> GetOrdersByUserID(int id);
        OrderStatus GetOrderStatus(int id);
        bool UpdateOrderStatus(int id, OrderStatus newStatus);
        bool DeleteOrder(int id);
        bool AddOrder(Order order);

        ///<summary>
        ///User related methods
        ///</summary>

        IQueryable<User> GetAllUsers();
        IQueryable<User> GetUsersByRole(Role role);
        bool AddUser(User user);

        ///<summary>
        ///BookCategories related methods
        ///</summary>
        ///
        //IQueryable<Book> GetBooksByCategorie(Category category);
    }
}
