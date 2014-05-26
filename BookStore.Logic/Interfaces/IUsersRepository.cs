using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<UserModel> GetUsers();
        string GetRole(int userId);
        UserModel GetUser(string login, string password);
        bool AddUser(UserModel user, string password);
    }
}
