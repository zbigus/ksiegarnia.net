using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using BookStore.Logic.Managers;

namespace BookStore.Logic.Models
{
    public class SelectUserRolesViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }

        public SelectUserRolesViewModel()
        {
            Roles = new List<SelectRoleEditorViewModel>();
        }

        public SelectUserRolesViewModel(User user)
        {
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            var identityManager = new IdentityManager(new BookStoreContext());

            var allRoles = identityManager.GetAllRoles(user.Id);
            Roles = allRoles
                .Select(pair => new SelectRoleEditorViewModel {RoleName = pair.Key.Name, Selected = pair.Value})
                .ToList();

        }
    }
}