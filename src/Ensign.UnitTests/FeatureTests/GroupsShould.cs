using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class GroupsShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void ReturnGroups()
        {
            var groups = BuildFeatureWithGroups();

            var result = Feature.Groups();

            Assert.IsNotNull(result);
            Assert.AreEqual(groups, result);
        }

    }
}
