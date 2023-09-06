using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;  // Replace with your actual namespace
using AlgoLayout.Core.Algorithms;  // Replace with your actual namespace
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.LayoutAutomation
{
    [TestFixture]
    public class LayoutOptimizationTest
    {
        private ILayoutOptimization _layoutOptimization;
        private ILayout _mockLayout;

        [SetUp]
        public void Setup()
        {
            _layoutOptimization = new LayoutOptimization();  // Replace with your actual LayoutOptimization class
            _mockLayout = MockRepository.GenerateMock<ILayout>();
        }

        [Test]
        public void TestOptimizeLayout()
        {
            // Arrange
            var room = new Room("Living Room");
            var rooms = new List<Room> { room };

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act
            var result = _layoutOptimization.OptimizeLayout(_mockLayout);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("Optimized", room.Status);  // Replace with your actual status property

            _mockLayout.VerifyAllExpectations();
        }

        [Test]
        public void TestOptimizeLayout_Failed()
        {
            // Arrange
            var rooms = new List<Room>();

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act & Assert
            Assert.Throws<LayoutOptimizationException>(() => _layoutOptimization.OptimizeLayout(_mockLayout));

            _mockLayout.VerifyAllExpectations();
        }
    }
}
