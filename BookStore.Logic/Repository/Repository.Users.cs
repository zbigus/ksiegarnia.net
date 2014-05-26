using BookStore.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public IEnumerable<UserModel> GetUsers()
        {
            return _db.Users.Select(user => UserModel.Create(user)).ToList();
        }

        public string GetRole(int userId)
        {
            //TODO: wyrzucić błąd jak się nie znajdzie
            var user = _db.Users.Find(userId);
            return _db.Roles.Find(user.RoleId).Name;
        }

        public UserModel GetUser(string login, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            return user == null ? null : UserModel.Create(user);
        }

        public bool AddUser(UserModel user, string password)
        {
            var u = _db.Users.FirstOrDefault(arg => arg.Login == user.Login);
            if (u != null)
                return false;
            _db.Users.Add(new User { Address = user.Address, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Login = user.Login, Password = password, });
            _db.SaveChanges();
            return true;
        }
    }
}
