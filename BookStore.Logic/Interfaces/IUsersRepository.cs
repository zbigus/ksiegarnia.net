using System.Linq;
using BookStore.Entities.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IUsersRepository
    {
        IQueryable<User> GetAllUsers();
        IQueryable<User> GetUsersByRole(string role);
        IQueryable<User> GetUsersIdByLogin(string login);
        bool DeleteUser(int id);
    }
}