using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BookStore.Logic.Managers
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {
        }

        public static UserManager Create()
        {
            return Create(new BookStoreContext());
        }

        public static UserManager Create(BookStoreContext context)
        {
            var manager = new UserManager(new UserStore<User>(context));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            return manager;
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options,
            IOwinContext context)
        {
            var manager = Create(context.Get<BookStoreContext>());
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}