using BookStore.Entities.Models;
using System.Linq;

namespace BookStore.Logic.Repository
{
    //TODO: Może partial zamiast oznaczania metod przez komentarze? Albo można to też rozbić na osobne interfejsy
    public interface IRepository {
        
        /// <summary>
        /// Book related methods 
        /// </summary>
        
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int id);
        bool DeleteBook(int id);
        bool AddBook(Book b);

        ///<summary>
        ///Attachment related methods
        ///</summary>

        Attachment GetAttachmentById(int id);
        bool AddAttachment(Attachment a);
        bool DeleteAttachment(int id);

        ///<summary>
        ///Order related methods
        ///</summary>

        IQueryable<Order> GetAllOrders();
        IQueryable<Order> GetOrdersByBookId(int id);
        IQueryable<Order> GetOrdersByUserId(int id);
        OrderStatus GetOrderStatus(int id);
        bool UpdateOrderStatus(int id, OrderStatus newStatus);
        bool DeleteOrder(int id);
        bool AddOrder(Order order);

        ///<summary>
        ///User related methods
        ///</summary>

        IQueryable<User> GetAllUsers();
        IQueryable<User> GetUsersByRole(string role);
        bool AddUser(User user);

        ///<summary>
        ///BookCategories related methods
        ///</summary>
        ///
        //IQueryable<Book> GetBooksByCategorie(Category category);
    }
}
