using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class RemoveGroupShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void RemoveGroup()
        {
            var groups = BuildFeatureWithGroups();
            var expectedGroupCount = groups.Count() - 1;
            Assert.AreEqual(groups.Count(), Feature.Groups().Count());

            Feature.RemoveGroup(GroupOne);

            Assert.AreEqual(expectedGroupCount, Feature.Groups().Count());
            Assert.IsNull(Feature.Groups().FirstOrDefault(x => x.Name == GroupOne));
        }

        [TestMethod]
        public void DoNotThrowExceptionWhenGroupDoesNotExist()
        {
            var groups = BuildFeatureWithGroups();
            var expectedGroupCount = groups.Count();
            Assert.AreEqual(groups.Count(), Feature.Groups().Count());            

            Feature.RemoveGroup("SomeUnknownFeature");

            Assert.AreEqual(expectedGroupCount, Feature.Groups().Count());
        }

    }
}
