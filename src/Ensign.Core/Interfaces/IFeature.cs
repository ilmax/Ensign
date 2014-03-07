namespace EnsignLib.Core.Interfaces
{
    public interface IFeature
    {
        string Name { get; }
        int GlobalPercentage { get; }

        bool IsEnabled();
        bool IsEnabledFor(int userId);

        void Enable();
        void EnablePercentage(int percentage);

        void Disable();
    }
}