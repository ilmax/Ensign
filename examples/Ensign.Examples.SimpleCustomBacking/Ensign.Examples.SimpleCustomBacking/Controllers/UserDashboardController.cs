using System.Web.Mvc;
using EnsignLib.Core;
using EnsignLib.Examples.SimpleCustomBacking.Code;
using EnsignLib.Examples.SimpleCustomBacking.Models;
using Microsoft.AspNet.Identity;

namespace EnsignLib.Examples.SimpleCustomBacking.Controllers
{
    [Authorize]
    public class UserDashboardController : Controller
    {
        private Ensign _ensign;
        private Ensign Ensign
        {
            get { return _ensign ?? (_ensign = new Ensign(new SimpleSessionBackingStore())); }
        }

        public ActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                NewHotness = Ensign.Feature("NewHotness").IsEnabledFor(User.Identity.GetUserName())
            };

            return View(viewModel);
        }
	}
}