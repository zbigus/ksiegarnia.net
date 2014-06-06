using System.Collections.Generic;
using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Logic.Managers
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
            IdentityResult idResult = _roleManager.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }

        public bool CreateUser(User user, string password)
        {
            IdentityResult idResult = _userManager.Create(user, password);
            return idResult.Succeeded;
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            IdentityResult idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            User user = _userManager.FindById(userId);
            var identityUserRoles = new List<IdentityUserRole>(user.Roles);
            foreach (IdentityUserRole userRole in identityUserRoles)
            {
                IdentityRole role = _roleManager.FindById(userRole.RoleId);
                _userManager.RemoveFromRole(userId, role.Name);
            }
        }
    }
}