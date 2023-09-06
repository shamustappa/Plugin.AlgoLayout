using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.GraphVisualization;

namespace AlgoLayout.Tests.GraphVisualization
{
    [TestFixture]
    public class GraphingAlgorithmTest
    {
        private IGraphingAlgorithm _graphingAlgorithm;
        private IGraphData _mockGraphData;

        [SetUp]
        public void Setup()
        {
            _graphingAlgorithm = new GraphingAlgorithm();  // Replace with your actual GraphingAlgorithm class
            _mockGraphData = MockRepository.GenerateMock<IGraphData>();
        }

        [Test]
        public void TestRunAlgorithm()
        {
            // Arrange
            var nodes = new List<Node> { new Node("Node1") };
            var edges = new List<Edge> { new Edge("Node1", "Node2") };

            _mockGraphData.Expect(g => g.Nodes).Return(nodes);
            _mockGraphData.Expect(g => g.Edges).Return(edges);

            // Act
            var result = _graphingAlgorithm.RunAlgorithm(_mockGraphData);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.UpdatedNodes.Count);  // Replace with your actual updated node count property
            Assert.AreEqual(1, result.UpdatedEdges.Count);  // Replace with your actual updated edge count property

            _mockGraphData.VerifyAllExpectations();
        }

        [Test]
        public void TestRunAlgorithm_Failed()
        {
            // Arrange
            var nodes = new List<Node>();
            var edges = new List<Edge>();

            _mockGraphData.Expect(g => g.Nodes).Return(nodes);
            _mockGraphData.Expect(g => g.Edges).Return(edges);

            // Act & Assert
            Assert.Throws<GraphingAlgorithmException>(() => _graphingAlgorithm.RunAlgorithm(_mockGraphData));

            _mockGraphData.VerifyAllExpectations();
        }
    }
}
