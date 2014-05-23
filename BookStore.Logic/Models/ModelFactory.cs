using System.Security.Cryptography.X509Certificates;
using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Models
{
    public class ModelFactory
    {
        public ModelFactory(){
        }

        public UserModel Create(User user)
        {
            return new UserModel
            {
                ID = user.ID,
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                RoleID = user.RoleID
            };
        }

        public SampleBookModel CreateInitial(Book b)
        {
            return new SampleBookModel
            {
                Author = b.Author,
                Title =  b.Title,
                Price = b.Price
            };
        }
    }
}
