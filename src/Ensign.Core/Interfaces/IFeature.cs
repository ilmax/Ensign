namespace EnsignLib.Core.Interfaces
{
    public interface IFeature
    {
        string Name { get; }

        bool IsEnabled();
        bool IsEnabledFor(int userId);

        void Enable();
        void EnablePercentage(double percentage);

        void Disable();
    }
}