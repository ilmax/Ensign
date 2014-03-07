using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class GroupShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void ReturnExistingGroupWhenGroupExists()
        {
            var groups = BuildFeatureWithGroups();
            var firstGroup = groups.First();

            var result = Feature.Group(firstGroup.Name);

            Assert.IsNotNull(result);
            Assert.AreEqual(firstGroup.Name, result.Name);
            Assert.AreEqual(firstGroup.Users.Count(), result.Users.Count());

            Assert.AreEqual(groups.Count(), Feature.Groups().Count());
        }

        [TestMethod]
        public void ReturnNewGroupWhenGroupDoesNotExist()
        {
            const string groupName = "SomeGroup";

            var result = Feature.Group(groupName);

            Assert.IsNotNull(result);
            Assert.AreEqual(groupName, result.Name);
            Assert.AreEqual(0, result.Users.Count());

            Assert.AreEqual(1, Feature.Groups().Count());
            Assert.AreEqual(groupName, Feature.Groups().First().Name);
        }

    }
}
