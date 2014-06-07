using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Entities.Models
{
    public class Role : IdentityRole
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public Role()
        {
        }

        public Role(string name) : base(name)
        {
        }
    }
}