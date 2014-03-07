using AutoMoq;
using EnsignLib.Core;
using EnsignLib.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnsignLib.UnitTests
{
    [TestClass]
    public class EnsignShould
    {
        private const string FeatureName = "someFeature";

        private Ensign _ensign;

        private Mock<IBackingStore> _backingStore;
        private Mock<IFeature> _feature;

        [TestInitialize]
        public void Setup()
        {
            var mocker = new AutoMoqer();

            _backingStore = mocker.GetMock<IBackingStore>();
            _feature = mocker.GetMock<IFeature>();

            _feature.SetupGet(x => x.Name).Returns(FeatureName);
            _backingStore.Setup(x => x.Get(FeatureName)).Returns(_feature.Object);

            _ensign = mocker.Resolve<Ensign>();
        }

        [TestMethod]
        public void GetFeatureFromBackingStore()
        {
            var result = _ensign.Feature(FeatureName);

            Assert.IsNotNull(result);
            Assert.AreEqual(_feature.Object, result);
        }

        [TestMethod]
        public void GetNewFeatureWhenBackingStoreReturnsNull()
        {
            _backingStore.Setup(x => x.Get(FeatureName)).Returns((IFeature)null);

            var result = _ensign.Feature(FeatureName);

            Assert.IsNotNull(result);
            Assert.AreEqual(FeatureName, result.Name);
        }

    }
}
