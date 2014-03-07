using System;

namespace EnsignLib.Core.Interfaces
{
    public interface IFeature
    {
        string Name { get; }
        int GlobalPercentage { get; }

        bool IsEnabled();
        bool IsEnabledFor(Object userId);

        IFeature Enable();
        IFeature EnablePercentage(int percentage);

        IFeature Disable();

        IFeature Save();
    }
}