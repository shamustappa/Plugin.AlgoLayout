using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.MachineLearning;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.MachineLearning
{
    [TestFixture]
    public class FeatureExtractionTest
    {
        private IFeatureExtraction _featureExtraction;
        private ILayout _mockLayout;

        [SetUp]
        public void Setup()
        {
            _featureExtraction = new FeatureExtraction();  // Replace with your actual FeatureExtraction class
            _mockLayout = MockRepository.GenerateMock<ILayout>();
        }

        [Test]
        public void TestExtractFeatures()
        {
            // Arrange
            var room = new Room("Living Room", 100);
            var rooms = new List<Room> { room };

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act
            var result = _featureExtraction.ExtractFeatures(_mockLayout);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(100, result["Living Room Area"]);  // Replace with your actual feature key

            _mockLayout.VerifyAllExpectations();
        }

        [Test]
        public void TestExtractFeatures_Failed()
        {
            // Arrange
            var rooms = new List<Room>();

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act & Assert
            Assert.Throws<FeatureExtractionException>(() => _featureExtraction.ExtractFeatures(_mockLayout));

            _mockLayout.VerifyAllExpectations();
        }
    }
}
