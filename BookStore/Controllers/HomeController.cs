using System.Web.Mvc;

namespace BookStore.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za wyświetlenie głównego okna
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Pobiera główny widok kontrolera
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
