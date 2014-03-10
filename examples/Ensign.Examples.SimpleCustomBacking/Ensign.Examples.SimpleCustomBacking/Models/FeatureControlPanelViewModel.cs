using EnsignLib.Core.Interfaces;

namespace EnsignLib.Examples.SimpleCustomBacking.Models
{
    public class FeatureControlPanelViewModel
    {
        public IFeature HomepageFeature { get; set; }
        public IFeature LoggedInFeature { get; set; }
    }
}