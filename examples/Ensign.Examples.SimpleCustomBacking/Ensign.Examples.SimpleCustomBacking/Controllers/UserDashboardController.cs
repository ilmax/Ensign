using System.Web.Mvc;

namespace EnsignLib.Examples.SimpleCustomBacking.Controllers
{
    [Authorize]
    public class UserDashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}