using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Algorithms;
using AlgoLayout.Core.Models;

namespace AlgoLayout.Tests.LayoutAutomation
{
    [TestFixture]
    public class DijkstrasAlgorithmTest
    {
        private IDijkstra _dijkstra;
        private IGraph _mockGraph;

        [SetUp]
        public void Setup()
        {
            _dijkstra = new Dijkstra();  // Replace with your actual Dijkstra class
            _mockGraph = MockRepository.GenerateMock<IGraph>();
        }

        [Test]
        public void TestFindShortestPath()
        {
            // Arrange
            var startNode = new Node("A");
            var endNode = new Node("B");
            var nodes = new List<Node> { startNode, endNode };
            var edges = new List<Edge>
            {
                new Edge(startNode, endNode, 1)
            };

            _mockGraph.Expect(g => g.Nodes).Return(nodes);
            _mockGraph.Expect(g => g.Edges).Return(edges);

            // Act
            var result = _dijkstra.FindShortestPath(_mockGraph, startNode, endNode);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Distance);
            Assert.AreEqual(endNode, result.EndNode);

            _mockGraph.VerifyAllExpectations();
        }

        [Test]
        public void TestFindShortestPath_NoPath()
        {
            // Arrange
            var startNode = new Node("A");
            var endNode = new Node("B");
            var nodes = new List<Node> { startNode, endNode };
            var edges = new List<Edge>();

            _mockGraph.Expect(g => g.Nodes).Return(nodes);
            _mockGraph.Expect(g => g.Edges).Return(edges);

            // Act & Assert
            Assert.Throws<PathNotFoundException>(() => _dijkstra.FindShortestPath(_mockGraph, startNode, endNode));

            _mockGraph.VerifyAllExpectations();
        }
    }
}
