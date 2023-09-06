using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.GraphVisualization;

namespace AlgoLayout.Tests.GraphVisualization
{
    [TestFixture]
    public class GraphRendererTest
    {
        private IGraphRenderer _graphRenderer;
        private IGraphData _mockGraphData;

        [SetUp]
        public void Setup()
        {
            _graphRenderer = new GraphRenderer();  // Replace with your actual GraphRenderer class
            _mockGraphData = MockRepository.GenerateMock<IGraphData>();
        }

        [Test]
        public void TestRenderGraph()
        {
            // Arrange
            var nodes = new List<Node> { new Node("Node1") };
            var edges = new List<Edge> { new Edge("Node1", "Node2") };

            _mockGraphData.Expect(g => g.Nodes).Return(nodes);
            _mockGraphData.Expect(g => g.Edges).Return(edges);

            // Act
            var result = _graphRenderer.RenderGraph(_mockGraphData);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Rendered", result.Status);  // Replace with your actual status property

            _mockGraphData.VerifyAllExpectations();
        }

        [Test]
        public void TestRenderGraph_Failed()
        {
            // Arrange
            var nodes = new List<Node>();
            var edges = new List<Edge>();

            _mockGraphData.Expect(g => g.Nodes).Return(nodes);
            _mockGraphData.Expect(g => g.Edges).Return(edges);

            // Act & Assert
            Assert.Throws<GraphRendererException>(() => _graphRenderer.RenderGraph(_mockGraphData));

            _mockGraphData.VerifyAllExpectations();
        }
    }
}
