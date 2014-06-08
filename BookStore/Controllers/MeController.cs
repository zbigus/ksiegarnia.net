using System.Web;
using System.Web.Http;
using BookStore.Entities.Models;
using BookStore.Logic.Managers;
using BookStore.Logic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BookStore.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        private UserManager _userManager;

        public MeController()
        {
        }

        public MeController(UserManager userManager)
        {
            UserManager = userManager;
        }

        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Me
        [Authorize(Roles = Role.Admin)]
        public GetViewModel Get()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return new GetViewModel { UserName = user.UserName};
        }
    }
}