using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class EnablePercentageShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void SetGlobalPercentageAndSave()
        {
            const int percentage = 57;
            Assert.AreEqual(0, Feature.GlobalPercentage);

            var result = Feature.EnablePercentage(percentage);

            Assert.IsNotNull(result);
            Assert.AreEqual(percentage, result.GlobalPercentage);
            BackingStore.Verify(x => x.Save(Feature), Times.Once());
        }

        [TestMethod]
        public void ThrowIfPercentageIsLessThanZero()
        {
            try
            {
                Feature.EnablePercentage(-1);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Percentage must be between 0 and 100.", ex.Message);
            }
        }

        [TestMethod]
        public void ThrowIfPercentageIsGreaterThan100()
        {
            try
            {
                Feature.EnablePercentage(101);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Percentage must be between 0 and 100.", ex.Message);
            }
        }

    }
}
