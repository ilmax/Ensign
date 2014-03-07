using System;
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

            var result = Feature.IsEnabledFor(Guid.Parse("97570356-e82d-4516-abdc-d91feab16542"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnFalseWhenGuidHashCodeModsAbovePercentage()
        {
            BuildFeatureWithPercentage(50);

            var result = Feature.IsEnabledFor(Guid.Parse("245d6e48-730f-4e77-8c1a-60100358717c"));

            Assert.IsFalse(result);
        }

    }
}
