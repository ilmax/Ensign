namespace EnsignLib.Core.Interfaces
{
    public interface IFeatureHydrator
    {
        string DehydrateToString(IFeature feature);
        IFeature HydrateFrom(string dehydratedFeature, IBackingStore backingStore);
    }
}
