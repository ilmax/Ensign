using System.Collections.Generic;
using System.Web.Mvc;
using EnsignLib.Core;
using EnsignLib.Examples.SimpleCustomBacking.Code;
using EnsignLib.Examples.SimpleCustomBacking.Models;

namespace EnsignLib.Examples.SimpleCustomBacking.Controllers
{
    public class FeatureController : Controller
    {
        private Ensign _ensign;
        private Ensign Ensign
        {
            get { return _ensign ?? (_ensign = new Ensign(new SimpleSessionBackingStore())); }
        }

        public ActionResult Index()
        {
            return View(new FeatureControlPanelViewModel
            {
                HomepageFeature = Ensign.Feature("HomepageAB"),
                LoggedInFeature = Ensign.Feature("NewHotness"),
                UserIds = new List<string>
                {
                    UserKeys.UserOneId,
                    UserKeys.UserTwoId,
                    UserKeys.UserThreeId
                }
            });
        }

        [HttpPost]
        public ActionResult FeatureToggle(string name)
        {
            var feature = Ensign.Feature(name);

            if (feature.IsEnabled())
            {
                feature.Disable();
            }
            else
            {
                feature.Enable();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult HomeSetPercentage(int percentage)
        {
            Ensign.Feature("HomepageAB").EnablePercentage(percentage);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ModifyGroup(string submit)
        {
            var submitArray = submit.Split('-');
            var action = submitArray[0];
            var userId = submitArray[1];

            var feature = Ensign.Feature("NewHotness");
            if (action.Equals("add"))
            {
                feature.Group("SuperGroup").AddUser(userId);
            }
            else
            {
                feature.Group("SuperGroup").RemoveUser(userId);
            }
            feature.Save();

            return RedirectToAction("Index");
        }

	}
}