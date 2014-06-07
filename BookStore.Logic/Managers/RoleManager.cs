using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Logic.Managers
{
    public class RoleManager : RoleManager<Role>
    {
        public RoleManager(IRoleStore<Role, string> store) : base(store)
        {
        }

        public static RoleManager Create()
        {
            return Create(new BookStoreContext());
        }

        public static RoleManager Create(BookStoreContext context)
        {
            return new RoleManager(new RoleStore<Role>(context));
        }
    }
}