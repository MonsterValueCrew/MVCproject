using System.Web.Mvc;

namespace MonsterValueCrew.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Courses()
        {
            ViewBag.Message = "Your courses page.";

            return View();
        }
    }
}