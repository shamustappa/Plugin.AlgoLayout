using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models; 
using AlgoLayout.Core.GraphVisualization; 
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.GraphVisualization
{
    [TestFixture]
    public class GraphDataPreparationTest
    {
        private IGraphDataPreparation _graphDataPreparation;
        private ILayout _mockLayout;

        [SetUp]
        public void Setup()
        {
            _graphDataPreparation = new GraphDataPreparation();  // Replace with your actual GraphDataPreparation class
            _mockLayout = MockRepository.GenerateMock<ILayout>();
        }

        [Test]
        public void TestPrepareGraphData()
        {
            // Arrange
            var room = new Room("Living Room", 100);
            var rooms = new List<Room> { room };

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act
            var result = _graphDataPreparation.PrepareGraphData(_mockLayout);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Nodes.Count);  // Replace with your actual node count property
            Assert.AreEqual(0, result.Edges.Count);  // Replace with your actual edge count property

            _mockLayout.VerifyAllExpectations();
        }

        [Test]
        public void TestPrepareGraphData_Failed()
        {
            // Arrange
            var rooms = new List<Room>();

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act & Assert
            Assert.Throws<GraphDataPreparationException>(() => _graphDataPreparation.PrepareGraphData(_mockLayout));

            _mockLayout.VerifyAllExpectations();
        }
    }
}
