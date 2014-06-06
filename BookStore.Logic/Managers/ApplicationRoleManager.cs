using BookStore.Entities.Dal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Logic.Managers
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }

        public static ApplicationRoleManager Create()
        {
            return Create(new BookStoreContext());
        }

        public static ApplicationRoleManager Create(BookStoreContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context));
        }
    }
}