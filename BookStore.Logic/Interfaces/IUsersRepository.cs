using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IUsersRepository
    {
        IQueryable<User> GetAllUsers();
        IQueryable<User> GetUsersByRole(string role);
        IQueryable<User> GetUsersIDByLogin(string login);
        bool DeleteUser(int id);
    }
}
