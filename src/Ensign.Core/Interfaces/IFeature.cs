namespace Ensign.Core.Interfaces
{
    public interface IFeature
    {
        bool IsEnabled();
        bool IsEnabledFor(int userId);

        void Enable();
        void EnablePercentage(double percentage);

        void Disable();
    }
}