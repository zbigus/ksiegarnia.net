using BookStore.Entities.Helpers;
using BookStore.Entities.Models;
using BookStore.Logic.Extensions;

namespace BookStore.Logic.Models
{
    public class ModelFactory
    {
        public UserModel Create(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            };
        }

        public SimpleBookModel CreateInitial(Book b)
        {
            return new SimpleBookModel(b);
        }

        public BookModel Create(Book b)
        {
            return new BookModel(b);
        }

        public CategoryModel Create(Category c)
        {
            return new CategoryModel(c);
        }

        public OrderModel Create(Order o)
        {
            return new OrderModel
            {
                Id = o.Id,
                BookTitle = o.Book.Title,
                Status = o.Status.GetAttribute<ResxAttribute>().Name
            };
        }
    }
}