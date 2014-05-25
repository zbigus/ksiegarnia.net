using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.RepositoryInterfaces
{
    public interface IUsersRepository
    {
        IQueryable<User> GetAllUsers();
        IQueryable<User> GetUsersByRole(string role);
        bool AddUser(User user);
    }
}
