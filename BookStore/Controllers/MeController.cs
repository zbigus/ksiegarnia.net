using System.Web;
using System.Web.Http;
using BookStore.Logic.Managers;
using BookStore.Logic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BookStore.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za wyświetlenie danych o aktualnie zalogowanym użytkowniku
    /// </summary>
    [Authorize]
    public class MeController : ApiController
    {
        private UserManager _userManager;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MeController()
        {
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="userManager">Menadżer użytkowników</param>
        public MeController(UserManager userManager)
        {
            UserManager = userManager;
        }

        /// <summary>
        /// Instancja menadżera użytkowników
        /// </summary>
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
        /// <summary>
        /// Pobranie informacji o aktualnie zalogowanym użytkowniku
        /// </summary>
        /// <returns>Model informacji o użytkowniku</returns>
        [Authorize]
        public GetViewModel Get()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user == null)
                return null;
            return new GetViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}