using System.Collections.Generic;
using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Entities.Managers
{
    public class IdentityManager
    {
        private readonly ApplicationRoleManager _roleManager;
        private readonly ApplicationUserManager _userManager;
        
        public IdentityManager(BookStoreContext context)
        {
            _roleManager = ApplicationRoleManager.Create(context);
            _userManager = ApplicationUserManager.Create(context);
        }

        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
        }
        
        public bool CreateRole(string name)
        {
            var idResult = _roleManager.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }

        public bool CreateUser(User user, string password)
        {
            var idResult = _userManager.Create(user, password);
            return idResult.Succeeded;
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            var user = _userManager.FindById(userId);
            var identityUserRoles = new List<IdentityUserRole>(user.Roles);
            foreach (var userRole in identityUserRoles)
            {
                var role = _roleManager.FindById(userRole.RoleId);
                _userManager.RemoveFromRole(userId, role.Name);
            }
        }
    }
}
