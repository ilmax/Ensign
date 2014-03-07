using EnsignLib.Core.Interfaces;

namespace EnsignLib.Core
{
    public class Ensign : IEnsign
    {
        private readonly IBackingStore _backingStore;

        public Ensign(IBackingStore backingStore)
        {
            _backingStore = backingStore;
        }

        public IFeature Feature(string name)
        {
            var feature = _backingStore.Get(name);

            return feature ?? new Feature(_backingStore, name);
        }
    }
}
