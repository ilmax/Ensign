using System;
using System.Web.Mvc;
using EnsignLib.Core;
using EnsignLib.Examples.SimpleCustomBacking.Code;
using EnsignLib.Examples.SimpleCustomBacking.Models;

namespace EnsignLib.Examples.SimpleCustomBacking.Controllers
{
    public class HomeController : Controller
    {
        private Ensign _ensign;
        private Ensign Ensign
        {
            get { return _ensign ?? (_ensign = new Ensign(new SimpleSessionBackingStore())); }
        }

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                HomepageB = Ensign.Feature("HomepageAB").IsEnabledFor(Guid.NewGuid())
            };

            return View(viewModel);
        }
        
    }
}