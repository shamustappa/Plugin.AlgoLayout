using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.MicrositeManagement;
using AlgoLayout.Core.Interfaces;
using System.Security.Policy;

namespace AlgoLayout.Tests.MicrositeManagement
{
    [TestFixture]
    public class SiteCreationTest
    {
        private ISiteCreation _siteCreation;
        private IMap _mockMap;

        [SetUp]
        public void Setup()
        {
            _siteCreation = new SiteCreation();  // Replace with actual SiteCreation class
            _mockMap = MockRepository.GenerateMock<IMap>();
        }

        [Test]
        public void TestCreateSite()
        {
            // Arrange
            var sites = new List<Site> { new Site("Park", 1000) };

            _mockMap.Expect(m => m.Sites).Return(sites);

            // Act
            var result = _siteCreation.CreateSite(_mockMap);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Created", result.Status);  // Replace with actual status property

            _mockMap.VerifyAllExpectations();
        }

        [Test]
        public void TestCreateSite_Failed()
        {
            // Arrange
            var sites = new List<Site>();

            _mockMap.Expect(m => m.Sites).Return(sites);

            // Act & Assert
            Assert.Throws<SiteCreationException>(() => _siteCreation.CreateSite(_mockMap));

            _mockMap.VerifyAllExpectations();
        }
    }
}
