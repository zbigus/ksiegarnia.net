using System.Web.Mvc;

namespace BookStore.SPA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
