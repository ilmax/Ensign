using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class IsEnabledForShould : FeatureTestBaseClass
    {
        [TestMethod]
        public void ReturnTrueWhenFeatureIs100PercentOn()
        {
            BuildFeatureWithPercentage(100);

            var result = Feature.IsEnabledFor(123);

            Assert.IsTrue(result);            
        }

        [TestMethod]
        public void ReturnFalseWhenFeatureIsOff()
        {
            Assert.AreEqual(0, Feature.GlobalPercentage);

            var result = Feature.IsEnabledFor(123);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnTrueWhenIntegerUserIdModsBelowPercentage()
        {
            BuildFeatureWithPercentage(2);

            var result = Feature.IsEnabledFor(9999901);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnFalseWhenIntegerUserIdModsEqualToPercentage()
        {
            BuildFeatureWithPercentage(2);

            var result = Feature.IsEnabledFor(9999902);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnFalseWhenIntegerUserIdModsAbovePercentage()
        {
            BuildFeatureWithPercentage(2);

            var result = Feature.IsEnabledFor(9999903);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnTrueWhenGuidHashCodeModsBelowPercentage()
        {
            BuildFeatureWithPercentage(50);

            var result = Feature.IsEnabledFor(BuildGuidWithLowModdingHashcode());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnFalseWhenGuidHashCodeModsAbovePercentage()
        {
            BuildFeatureWithPercentage(50);

            var result = Feature.IsEnabledFor(BuildGuidWithHighModdingHashcode());

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EnsureUserStaysEnabledWhenPercentageIsIncreased()
        {
            BuildFeatureWithPercentage(50);

            Assert.IsTrue(Feature.IsEnabledFor(BuildGuidWithLowModdingHashcode()));
            Assert.IsFalse(Feature.IsEnabledFor(BuildGuidWithHighModdingHashcode()));

            BuildFeatureWithPercentage(97);

            Assert.IsTrue(Feature.IsEnabledFor(BuildGuidWithLowModdingHashcode()));
            Assert.IsTrue(Feature.IsEnabledFor(BuildGuidWithHighModdingHashcode()));
        }

        [TestMethod]
        public void EnsureActualPercentageOfEnabledFeaturesIsPlusOrMinusOnePercent()
        {
            const int expectedPercentage = 5;
            const int totalUsers = 10000;

            var users = BuildRandomGuids(totalUsers);
            BuildFeatureWithPercentage(expectedPercentage);

            var enabledCount = users.Count(userId => Feature.IsEnabledFor(userId));
            var actualPercentage = (enabledCount / (decimal)totalUsers) * 100;

            Assert.IsTrue(actualPercentage >= (expectedPercentage - 1));
            Assert.IsTrue(actualPercentage <= (expectedPercentage + 1));
        }

        [TestMethod]
        public void ReturnTrueWhenUserIsInAnyGroup()
        {
            BuildFeatureWithGroups();
            Assert.AreEqual(0, Feature.GlobalPercentage);

            var result = Feature.IsEnabledFor(TestUserOne);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnFalseWhenUserIsNotInAnyGroup()
        {
            BuildFeatureWithGroups();
            Assert.AreEqual(0, Feature.GlobalPercentage);

            var result = Feature.IsEnabledFor("someUnknownUser");

            Assert.IsFalse(result);
        }

        private static Guid BuildGuidWithLowModdingHashcode()
        {
            return Guid.Parse("97570356-e82d-4516-abdc-d91feab16542");
        }

        private static Guid BuildGuidWithHighModdingHashcode()
        {
            return Guid.Parse("5d6fb4d8-042c-48e7-8e1b-d78ad0b74ecc");
        }

        private static IEnumerable<Guid> BuildRandomGuids(int howMany)
        {
            var users = new List<Guid>();
            for (var i = 0; i < howMany; i++)
            {
                users.Add(Guid.NewGuid());
            }

            return users;
        }

    }
}
