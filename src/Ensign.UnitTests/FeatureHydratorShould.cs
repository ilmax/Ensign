using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using EnsignLib.Core;
using EnsignLib.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnsignLib.UnitTests
{
    [TestClass]
    public class FeatureHydratorShould
    {
        private const string FeatureName = "someFeature";
        private const int Percentage = 57;
        protected const string GroupOne = "groupOne";
        protected const string GroupTwo = "groupTwo";
        protected readonly string TestUserOne = Guid.NewGuid().ToString();
        protected readonly string TestUserTwo = Guid.NewGuid().ToString();
        protected readonly string TestUserThree = Guid.NewGuid().ToString();
        protected readonly string TestUserFour = Guid.NewGuid().ToString();

        private FeatureHydrator _hydrator;
        private Mock<IBackingStore> _backingStore;

        [TestInitialize]
        public void Setup()
        {
            var mocker = new AutoMoqer();
            _backingStore = mocker.GetMock<IBackingStore>();

            _hydrator = new FeatureHydrator();
        }

        [TestMethod]
        public void DehydrateToString_ReturnValidStringForFeature()
        {
            var feature = new Feature(_backingStore.Object, FeatureName, Percentage, BuildGroups());

            var result = _hydrator.DehydrateToString(feature);

            Assert.AreEqual(BuildDehydratedString(), result);
        }

        [TestMethod]
        public void Hydrate_RehydrateObjectWithGivenString()
        {
            var result = _hydrator.HydrateFrom(BuildDehydratedString(), _backingStore.Object);

            Assert.IsNotNull(result);
            Assert.AreEqual(FeatureName, result.Name);
            Assert.AreEqual(Percentage, result.GlobalPercentage);
            Assert.AreEqual(2, result.Groups().Count());

            var groupOne = result.Group(GroupOne);
            Assert.IsNotNull(groupOne);
            Assert.AreEqual(GroupOne, groupOne.Name);
            Assert.AreEqual(3, groupOne.Users.Count());

            var groupTwo = result.Group(GroupTwo);
            Assert.IsNotNull(groupTwo);
            Assert.AreEqual(GroupTwo, groupTwo.Name);
            Assert.AreEqual(1, groupTwo.Users.Count());            
        }

        [TestMethod]
        public void Hydrate_ThrowExceptionWhenHydrationFails()
        {
            const string badDehydratedString = "ldkkldkld|kdkldldkl|789:00";

            try
            {
                _hydrator.HydrateFrom(badDehydratedString, _backingStore.Object);
                Assert.Fail();
            }
            catch (HydrationException ex)
            {
                Assert.AreEqual("Could not rehydrate feature from string. Please check the format.", ex.Message);
                Assert.AreEqual(badDehydratedString, ex.AttemptedString);
            }
        }

        private List<IGroup> BuildGroups()
        {
            var groups = new List<IGroup>
            {
                new Group(GroupOne)
                    .AddUser(TestUserOne)
                    .AddUser(TestUserTwo)
                    .AddUser(TestUserThree),
                new Group(GroupTwo)
                    .AddUser(TestUserFour)
            };
            return groups;
        }

        private string BuildDehydratedString()
        {
            return string.Format("someFeature|57|groupOne:{0}:{1}:{2}|groupTwo:{3}", 
                TestUserOne, 
                TestUserTwo, 
                TestUserThree, 
                TestUserFour);
        }

    }
}
