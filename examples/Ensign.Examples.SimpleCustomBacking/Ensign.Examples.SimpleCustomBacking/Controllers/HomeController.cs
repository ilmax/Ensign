using System;
using System.Web.Mvc;
using EnsignLib.Core;
using EnsignLib.Examples.SimpleCustomBacking.Code;
using EnsignLib.Examples.SimpleCustomBacking.Models;

namespace EnsignLib.Examples.SimpleCustomBacking.Controllers
{
    public class HomeController : Controller
    {
        private SimpleSessionBackingStore _featureBacking;
        private Ensign _ensign;

        private SimpleSessionBackingStore FeatureBacking
        {
            get { return _featureBacking ?? (_featureBacking = new SimpleSessionBackingStore()); }
        }

        private Ensign Ensign
        {
            get { return _ensign ?? (_ensign = new Ensign(FeatureBacking)); }
        }

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                NewSexy = Ensign.Feature("NewSexy").IsEnabledFor(Guid.NewGuid())
            };

            return View(viewModel);
        }

        public ActionResult SetFeatureOn()
        {
            var feature = Ensign.Feature("NewSexy").Enable();

            return RedirectToAction("Index");
        }

        public ActionResult SetFeature50()
        {
            var feature = Ensign.Feature("NewSexy").EnablePercentage(50);

            return RedirectToAction("Index");
        }

        public ActionResult SetFeatureOff()
        {
            var feature = Ensign.Feature("NewSexy").Disable();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}