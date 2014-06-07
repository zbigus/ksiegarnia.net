using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Logic.Managers
{
    public class IdentityManager
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;

        public IdentityManager()
        {
            var context = new BookStoreContext();
            _roleManager = RoleManager.Create(context);
            _userManager = UserManager.Create(context);
        }

        public IdentityManager(BookStoreContext context)
        {
            _roleManager = RoleManager.Create(context);
            _userManager = UserManager.Create(context);
        }

        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
        }

        public bool CreateRole(string name)
        {
            return !RoleExists(name) && _roleManager.Create(new Role(name)).Succeeded;
        }

        public bool CreateUser(User user, string password)
        {
            var idResult = _userManager.Create(user, password);
            return idResult.Succeeded;
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            return RoleExists(roleName) && _userManager.AddToRole(userId, roleName).Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            _userManager.FindById(userId).Roles
                .Select(currenRole => _roleManager.FindById(currenRole.RoleId).Name)
                .ToList()
                .ForEach(role => _userManager.RemoveFromRole(userId, role));
        }

        public IEnumerable<Role> GetUserRoles(string userId)
        {
            return _userManager.FindById(userId).Roles
                .Select(userRole => _roleManager.FindById(userRole.RoleId)).ToList();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public Dictionary<Role, bool> GetAllRoles(string userId)
        {
            var userRoles = GetUserRoles(userId).ToList();
            return _roleManager.Roles.ToDictionary(identityRole => identityRole,
                userRoles.Contains);
        }
    }
}