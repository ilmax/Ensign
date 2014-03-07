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
        protected string FeatureName = "someFeature";

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

        private static List<IGroup> BuildGroups()
        {
            var groups = new List<IGroup>
            {
                new Group("GroupOne"),
                new Group("GroupTwo")
            };
            return groups;
        }

    }
}
