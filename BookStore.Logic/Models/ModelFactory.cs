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
            return new SimpleBookModel
            {
                Id=b.Id,
                Author = b.Author,
                Title =  b.Title,
                Price = b.Price
            };
        }
        public BookModel Create(Book b)
        {
            return new BookModel
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Price = b.Price,
                Isbn = b.Isbn,
                Publisher = b.Publisher,
                Year = b.Year,
                Description = b.Description
            };
        }

        public CategoryModel Create(Category c)
        {
            return new CategoryModel
            {
                Id = c.Id,
                Name = c.Name
            };
        }

        public OrderModel Create(Order o)
        {
            return new OrderModel
            {
                Id = o.Id,
                UserID = o.UserId,
                BookID = o.BookId,
                ShopComment = o.ShopComment,
                Status = o.Status
           };
        }

    }
}
