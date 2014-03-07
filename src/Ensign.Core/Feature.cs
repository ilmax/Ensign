using System;
using System.Collections.Generic;
using System.Linq;
using EnsignLib.Core.Interfaces;

namespace EnsignLib.Core
{
    public class Feature : IFeature
    {
        private const int MaxPercentage = 100;
        private const int MinPercentage = 0;

        private readonly IBackingStore _backingStore;
        private readonly List<IGroup> _groups; 

        public string Name { get; private set; }
        public int GlobalPercentage { get; private set; }

        public Feature(
            IBackingStore backingStore,
            string name, 
            int percentageEnabled = 0,
            List<IGroup> groups = null)
        {
            _backingStore = backingStore;
            _groups = groups ?? new List<IGroup>();
            Name = name;
            GlobalPercentage = percentageEnabled;
        }

        public bool IsEnabled()
        {
            return !(GlobalPercentage < MaxPercentage);
        }

        public bool IsEnabledFor(Object userId)
        {
            if (IsMinOrMaxPercentageSet())
            {
                return IsEnabled();
            }

            return NonNegativeHashCodeFor(userId) % MaxPercentage < GlobalPercentage ;
        }

        public IFeature Enable()
        {
            return ChangePercentageAndSave(MaxPercentage);
        }

        public IFeature EnablePercentage(int percentage)
        {
            if (percentage < MinPercentage || percentage > MaxPercentage)
            {
                throw new ArgumentException("Percentage must be between 0 and 100.");
            }

            return ChangePercentageAndSave(percentage);
        }

        public IFeature Disable()
        {
            return ChangePercentageAndSave(MinPercentage);
        }

        public IEnumerable<IGroup> Groups()
        {
            return _groups.AsEnumerable();
        }

        public IGroup Group(string name)
        {
            var group = _groups.FirstOrDefault(x => x.Name == name);

            if (group == null)
            {
                group = new Group(name);
                _groups.Add(group);
            }

            return group;
        }

        public IFeature Save()
        {
            _backingStore.Save(this);
            return this;
        }

        private IFeature ChangePercentageAndSave(int percentage)
        {
            GlobalPercentage = percentage;
            return Save();
        }

        private bool IsMinOrMaxPercentageSet()
        {
            return GlobalPercentage == MinPercentage 
                || GlobalPercentage == MaxPercentage;
        }

        private static int NonNegativeHashCodeFor(object userId)
        {
            return Math.Abs(userId.GetHashCode());
        }

    }
}
