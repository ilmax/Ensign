using System.Web;
using EnsignLib.Core;
using EnsignLib.Core.Interfaces;

namespace EnsignLib.Examples.SimpleCustomBacking.Code
{
    public class SimpleSessionBackingStore : IBackingStore
    {
        private const string FeatureKeyFormat = "feature:{0}";

        private IFeatureHydrator _featureHydrator;

        private IFeatureHydrator FeatureHydrator
        {
            get { return _featureHydrator ?? (_featureHydrator = new FeatureHydrator()); }
        }

        public IFeature Get(string feature)
        {
            var dehydrated = (string)HttpContext.Current.Session[BuildFeatureKey(feature)];

            if (string.IsNullOrEmpty(dehydrated))
            {
                return null;
            }

            return FeatureHydrator.HydrateFrom(dehydrated, this);
        }

        public void Save(Feature feature)
        {
            HttpContext.Current.Session[BuildFeatureKey(feature.Name)] = FeatureHydrator.DehydrateToString(feature);
        }

        private string BuildFeatureKey(string name)
        {
            return string.Format(FeatureKeyFormat, name);
        }
    }
}