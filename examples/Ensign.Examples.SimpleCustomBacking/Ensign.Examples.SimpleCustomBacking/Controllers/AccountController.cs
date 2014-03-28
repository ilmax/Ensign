using System.Web.Mvc;
using System.Web.Security;
using EnsignLib.Examples.SimpleCustomBacking.Models;

namespace EnsignLib.Examples.SimpleCustomBacking.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            FormsAuthentication.SetAuthCookie(viewModel.Username, false);

            return RedirectToAction("Index", "UserDashboard");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
	}
}