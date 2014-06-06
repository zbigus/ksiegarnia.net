using System;
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
            user.Roles.Select(userRole => _roleManager.FindById(userRole.RoleId))
                .ToList()
                .ForEach(role => _userManager.RemoveFromRole(userId, role.Name));
        }

        public IEnumerable<IdentityRole> GetUserRoles(string userId)
        {
            var user = _userManager.FindById(userId);
            return user.Roles.Select(userRole => _roleManager.FindById(userRole.RoleId)).ToList();
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public Dictionary<IdentityRole, bool> GetAllRoles(string userId)
        {
            var userRoles = GetUserRoles(userId).ToList();
            var result = new Dictionary<IdentityRole, bool>();
            foreach (var identityRole in _roleManager.Roles)
            {
                result.Add(identityRole, userRoles.Contains(identityRole));
            }
            return result;
        }
    }
}