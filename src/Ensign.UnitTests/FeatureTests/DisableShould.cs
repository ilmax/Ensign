using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class DisableShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void SetGlobalPercentageToZero()
        {
            BuildFeatureWithPercentage(100);
            Assert.AreEqual(100, Feature.GlobalPercentage);

            var result = Feature.Disable();
            
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.GlobalPercentage);
            BackingStore.Verify(x => x.Save(Feature), Times.Once());
        }
    }
}
