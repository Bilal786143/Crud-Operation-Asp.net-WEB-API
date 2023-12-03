using System.Web.Mvc;

namespace Crud_Operation_Asp.net_WEB_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
