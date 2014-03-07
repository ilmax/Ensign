using System;
using EnsignLib.Core.Interfaces;

namespace EnsignLib.Core
{
    public class Feature : IFeature
    {
        private const int MaxPercentage = 100;
        private const int MinPercentage = 0;

        private readonly IBackingStore _backingStore;

        public string Name { get; private set; }
        public int GlobalPercentage { get; private set; }

        public Feature(
            IBackingStore backingStore,
            string name, 
            int percentageEnabled = 0)
        {
            _backingStore = backingStore;
            Name = name;
            GlobalPercentage = percentageEnabled;
        }

        public bool IsEnabled()
        {
            return !(GlobalPercentage < MaxPercentage);
        }

        public bool IsEnabledFor(Object userId)
        {
            if (MinOrMaxPercentage())
            {
                return IsEnabled();
            }

            return userId.GetHashCode() % MaxPercentage < GlobalPercentage ;
        }

        public IFeature Enable()
        {
            ChangePercentageAndSave(MaxPercentage);
            return this;
        }

        public IFeature EnablePercentage(int percentage)
        {
            if (percentage < MinPercentage || percentage > MaxPercentage)
            {
                throw new ArgumentException("Percentage must be between 0 and 100.");
            }

            ChangePercentageAndSave(percentage);
            return this;
        }

        public IFeature Disable()
        {
            ChangePercentageAndSave(MinPercentage);
            return this;
        }

        private void ChangePercentageAndSave(int percentage)
        {
            GlobalPercentage = percentage;
            _backingStore.Save(this);
        }

        private bool MinOrMaxPercentage()
        {
            return GlobalPercentage == MinPercentage 
                || GlobalPercentage == MaxPercentage;
        }

    }
}
