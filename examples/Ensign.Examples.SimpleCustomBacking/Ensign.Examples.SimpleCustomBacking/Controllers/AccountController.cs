using System.Web.Mvc;

namespace EnsignLib.Examples.SimpleCustomBacking.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            return View();
        }
	}
}