using System;
using System.Collections.Generic;
using AutoMoq;
using EnsignLib.Core;
using EnsignLib.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnsignLib.UnitTests.FeatureTests
{
    [TestClass]
    public class FeatureTestBaseClass
    {
        protected const string FeatureName = "someFeature";
        protected const string GroupOne = "groupOne";
        protected const string GroupTwo = "groupTwo";
        protected readonly string TestUserOne = Guid.NewGuid().ToString();
        protected readonly string TestUserTwo = Guid.NewGuid().ToString();

        protected AutoMoqer Mocker;
        protected Feature Feature;

        protected Mock<IBackingStore> BackingStore;

        [TestInitialize]
        public void Setup()
        {
            Mocker = new AutoMoqer();

            BackingStore = Mocker.GetMock<IBackingStore>();
            Feature = new Feature(BackingStore.Object, FeatureName);
        }

        protected void BuildFeatureWithPercentage(int percentage)
        {
            Feature = new Feature(BackingStore.Object, FeatureName, percentage);
        }

        protected IEnumerable<IGroup> BuildFeatureWithGroups()
        {
            var groups = BuildGroups();
            Feature = new Feature(BackingStore.Object, FeatureName, groups: groups);

            return groups;
        }

        private List<IGroup> BuildGroups()
        {
            var groups = new List<IGroup>
            {
                new Group(GroupOne).AddUser(TestUserOne),
                new Group(GroupTwo).AddUser(TestUserTwo)
            };
            return groups;
        }

    }
}
