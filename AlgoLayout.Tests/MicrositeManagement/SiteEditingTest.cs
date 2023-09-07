using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;  // Replace with your actual namespace
using AlgoLayout.Core.MicrositeManagement;  // Replace with your actual namespace
using AlgoLayout.Core.Interfaces;
using System.Security.Policy;

namespace AlgoLayout.Tests.MicrositeManagement
{
    [TestFixture]
    public class SiteEditingTest
    {
        private ISiteEditing _siteEditing;
        private IMap _mockMap;

        [SetUp]
        public void Setup()
        {
            _siteEditing = new SiteEditing();  // Replace with your actual SiteEditing class
            _mockMap = MockRepository.GenerateMock<IMap>();
        }

        [Test]
        public void TestEditSite()
        {
            // Arrange
            var sites = new List<Site> { new Site("Park", 1000) };

            _mockMap.Expect(m => m.Sites).Return(sites);

            // Act
            var result = _siteEditing.EditSite(_mockMap, "Park", 2000);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Edited", result.Status);  // Replace with your actual status property

            _mockMap.VerifyAllExpectations();
        }

        [Test]
        public void TestEditSite_Failed()
        {
            // Arrange
            var sites = new List<Site>();

            _mockMap.Expect(m => m.Sites).Return(sites);

            // Act & Assert
            Assert.Throws<SiteEditingException>(() => _siteEditing.EditSite(_mockMap, "Park", 2000));

            _mockMap.VerifyAllExpectations();
        }
    }
}
