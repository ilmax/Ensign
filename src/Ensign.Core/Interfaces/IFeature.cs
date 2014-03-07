using System;
using System.Collections.Generic;

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

        IEnumerable<IGroup> Groups();
        IGroup Group(string name);
        void RemoveGroup(string name);

        IFeature Save();
    }
}