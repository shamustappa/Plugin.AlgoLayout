using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.IntelligentRoad;
using AlgoLayout.Core.GraphVisualization;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.IntelligentRoad
{
    [TestFixture]
    public class PathFindingTest
    {
        private IPathFinding _pathFinding;
        private IMap _mockMap;

        [SetUp]
        public void Setup()
        {
            _pathFinding = new PathFinding();  // Replace with actual PathFinding class
            _mockMap = MockRepository.GenerateMock<IMap>();
        }

        [Test]
        public void TestFindPath()
        {
            // Arrange
            var start = new Node(0, 0);
            var end = new Node(5, 5);
            var path = new List<Node> { start, new Node(1, 1), end };

            _mockMap.Expect(m => m.FindPath(Arg<Node>.Is.Anything, Arg<Node>.Is.Anything)).Return(path);

            // Act
            var result = _pathFinding.FindPath(start, end);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);  // Replace with actual count property

            _mockMap.VerifyAllExpectations();
        }

        [Test]
        public void TestFindPath_Failed()
        {
            // Arrange
            var start = new Node(0, 0);
            var end = new Node(5, 5);

            _mockMap.Expect(m => m.FindPath(Arg<Node>.Is.Anything, Arg<Node>.Is.Anything)).Return(null);

            // Act & Assert
            Assert.Throws<PathFindingException>(() => _pathFinding.FindPath(start, end));

            _mockMap.VerifyAllExpectations();
        }
    }
}
