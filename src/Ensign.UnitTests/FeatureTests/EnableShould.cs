 using Microsoft.VisualStudio.TestTools.UnitTesting;
 using Moq;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class EnableShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void SetGlobalPercentageTo100()
        {
            var result = Feature.Enable();
            
            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.GlobalPercentage);
            BackingStore.Verify(x => x.Save(Feature), Times.Once());
        }

    }
}
