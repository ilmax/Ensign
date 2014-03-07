using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class IsEnabledShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void ReturnFalseIfGlobalPercentageIsLessThan100()
        {
            BuildFeatureWithPercentage(57);

            var result = Feature.IsEnabled();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnTrueIfGlobalPercentageIs100()
        {
            BuildFeatureWithPercentage(100);

            var result = Feature.IsEnabled();

            Assert.IsTrue(result);
        }

    }
}
