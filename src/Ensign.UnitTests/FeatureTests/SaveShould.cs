using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class SaveShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void CallBackingStoreSave()
        {
            var result = Feature.Save();

            Assert.AreEqual(Feature, result);
            BackingStore.Verify(x => x.Save(Feature), Times.Once());
        }
    }
}
