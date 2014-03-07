using EnsignLib.Core.Interfaces;

namespace EnsignLib.Core
{
    public class Feature : IFeature
    {
        public string Name { get; private set; }

        public Feature(string name)
        {
            Name = name;
        }

        public bool IsEnabled()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEnabledFor(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Enable()
        {
            throw new System.NotImplementedException();
        }

        public void EnablePercentage(double percentage)
        {
            throw new System.NotImplementedException();
        }

        public void Disable()
        {
            throw new System.NotImplementedException();
        }
    }
}
