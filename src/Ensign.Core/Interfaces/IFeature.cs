using System;

namespace EnsignLib.Core.Interfaces
{
    public interface IFeature
    {
        string Name { get; }
        int GlobalPercentage { get; }

        bool IsEnabled();
        bool IsEnabledFor(int userId);
        bool IsEnabledfor(Guid userId);

        IFeature Enable();
        IFeature EnablePercentage(int percentage);

        IFeature Disable();
    }
}