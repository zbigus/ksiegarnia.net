using System.Linq;
using BookStore.Entities.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public IQueryable<User> GetAllUsers()
        {
            return null; //_db.Users.AsQueryable();
        }

        public IQueryable<User> GetUsersByRole(string role)
        {
            return null; //_db.Users.Where(s => s.Role.Name.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

        public IQueryable<User> GetUsersIDByLogin(string login)
        {
            return null; //_db.Users.Where(s => s.Login.Equals(login, StringComparison.OrdinalIgnoreCase));
        }

        public bool DeleteUser(int id)
        {
            User user = _db.Users.Find(id);
            if (user == null)
            {
                return false;
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
            return true;
        }
    }
}