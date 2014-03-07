namespace EnsignLib.Core.Interfaces
{
    public interface IBackingStore
    {
        IFeature Get(string feature);
        void Save(Feature feature);
    }
}
