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
                RoleId = user.RoleId
            };
        }

        public SimpleBookModel CreateInitial(Book b)
        {
            return new SimpleBookModel
            {
                Author = b.Author,
                Title =  b.Title,
                Price = b.Price
            };
        }
    }
}
