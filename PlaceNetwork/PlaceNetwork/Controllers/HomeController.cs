using System.Web.Mvc;

namespace PlaceNetwork.Controllers
{
    [IsAuthorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}