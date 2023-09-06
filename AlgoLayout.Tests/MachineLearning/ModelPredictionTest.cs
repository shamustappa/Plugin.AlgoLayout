using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.MachineLearning;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.MachineLearning
{
    [TestFixture]
    public class ModelPredictionTest
    {
        private IModelPrediction _modelPrediction;
        private ILayout _mockLayout;

        [SetUp]
        public void Setup()
        {
            _modelPrediction = new ModelPrediction();  // Replace with your actual ModelPrediction class
            _mockLayout = MockRepository.GenerateMock<ILayout>();
        }

        [Test]
        public void TestPredictLayoutQuality()
        {
            // Arrange
            var room = new Room("Living Room", 100);
            var rooms = new List<Room> { room };

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act
            var result = _modelPrediction.PredictLayoutQuality(_mockLayout);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("High", result.Quality);  // Replace with your actual quality property

            _mockLayout.VerifyAllExpectations();
        }

        [Test]
        public void TestPredictLayoutQuality_Failed()
        {
            // Arrange
            var rooms = new List<Room>();

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act & Assert
            Assert.Throws<ModelPredictionException>(() => _modelPrediction.PredictLayoutQuality(_mockLayout));

            _mockLayout.VerifyAllExpectations();
        }
    }
}
