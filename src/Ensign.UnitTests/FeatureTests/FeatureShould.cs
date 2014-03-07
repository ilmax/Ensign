using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class FeatureShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void SetAppropriateStartupValues()
        {
            Assert.AreEqual(FeatureName, Feature.Name);
            Assert.AreEqual(0, Feature.GlobalPercentage);
        }
    }
}
