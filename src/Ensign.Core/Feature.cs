using EnsignLib.Core.Interfaces;

namespace EnsignLib.Core
{
    public class Feature : IFeature
    {
        private const decimal MaxPercentage = 100;
        private const decimal MinPercentage = 0;

        private readonly IBackingStore _backingStore;

        public string Name { get; private set; }
        public decimal GlobalPercentage { get; private set; }

        public Feature(
            IBackingStore backingStore,
            string name, 
            decimal percentageEnabled = 0)
        {
            _backingStore = backingStore;
            Name = name;
            GlobalPercentage = percentageEnabled;
        }

        public bool IsEnabled()
        {
            return !(GlobalPercentage < MaxPercentage);
        }

        public bool IsEnabledFor(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Enable()
        {
            GlobalPercentage = MaxPercentage;
            _backingStore.Save(this);
        }

        public void EnablePercentage(double percentage)
        {
            throw new System.NotImplementedException();
        }

        public void Disable()
        {
            GlobalPercentage = MinPercentage;
            _backingStore.Save(this);
        }
    }
}
