using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.IntelligentRoad;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.IntelligentRoad
{
    [TestFixture]
    public class RoadDesignTest
    {
        private IRoadDesign _roadDesign;
        private IMap _mockMap;

        [SetUp]
        public void Setup()
        {
            _roadDesign = new RoadDesign();  // Replace with actual RoadDesign class
            _mockMap = MockRepository.GenerateMock<IMap>();
        }

        [Test]
        public void TestDesignRoad()
        {
            // Arrange
            var roads = new List<Road> { new Road("MainRoad", 100) };

            _mockMap.Expect(m => m.Roads).Return(roads);

            // Act
            var result = _roadDesign.DesignRoad(_mockMap);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Designed", result.Status);  // Replace with actual status property

            _mockMap.VerifyAllExpectations();
        }

        [Test]
        public void TestDesignRoad_Failed()
        {
            // Arrange
            var roads = new List<Road>();

            _mockMap.Expect(m => m.Roads).Return(roads);

            // Act & Assert
            Assert.Throws<RoadDesignException>(() => _roadDesign.DesignRoad(_mockMap));

            _mockMap.VerifyAllExpectations();
        }
    }
}
