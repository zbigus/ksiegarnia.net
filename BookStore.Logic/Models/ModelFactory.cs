using System.Collections.Generic;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    public class ModelFactory
    {
        public UserModel Create(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                //Role = user.Role.Name
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
                UserId = o.UserId,
                BookId = o.BookId,
                ShopComment = o.ShopComment,
                Status = o.Status
           };
        }

    }
}
