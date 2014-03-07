using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class RemoveAllGroupsShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void RemoveAllGroups()
        {
            var groups = BuildFeatureWithGroups();
            Assert.AreEqual(groups.Count(), Feature.Groups().Count());

            Feature.RemoveAllGroups();

            Assert.IsNotNull(Feature.Groups());
            Assert.AreEqual(0, Feature.Groups().Count());
        }

    }
}
