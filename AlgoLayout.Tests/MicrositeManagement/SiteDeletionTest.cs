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
    public class SiteDeletionTest
    {
        private ISiteDeletion _siteDeletion;
        private IMap _mockMap;

        [SetUp]
        public void Setup()
        {
            _siteDeletion = new SiteDeletion();  // Replace with actual SiteDeletion class
            _mockMap = MockRepository.GenerateMock<IMap>();
        }

        [Test]
        public void TestDeleteSite()
        {
            // Arrange
            var sites = new List<Site> { new Site("Park", 1000) };

            _mockMap.Expect(m => m.Sites).Return(sites);

            // Act
            var result = _siteDeletion.DeleteSite(_mockMap, "Park");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Deleted", result.Status);  // Replace with actual status property

            _mockMap.VerifyAllExpectations();
        }

        [Test]
        public void TestDeleteSite_Failed()
        {
            // Arrange
            var sites = new List<Site>();

            _mockMap.Expect(m => m.Sites).Return(sites);

            // Act & Assert
            Assert.Throws<SiteDeletionException>(() => _siteDeletion.DeleteSite(_mockMap, "Park"));

            _mockMap.VerifyAllExpectations();
        }
    }
}
