using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.MachineLearning;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.MachineLearning
{
    [TestFixture]
    public class ModelTrainingTest
    {
        private IModelTraining _modelTraining;
        private ILayout _mockLayout;

        [SetUp]
        public void Setup()
        {
            _modelTraining = new ModelTraining();  // Replace with your actual ModelTraining class
            _mockLayout = MockRepository.GenerateMock<ILayout>();
        }

        [Test]
        public void TestTrainModel()
        {
            // Arrange
            var room = new Room("Living Room", 100);
            var rooms = new List<Room> { room };

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act
            var result = _modelTraining.TrainModel(_mockLayout);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Trained", result.Status);  // Replace with your actual status property

            _mockLayout.VerifyAllExpectations();
        }

        [Test]
        public void TestTrainModel_Failed()
        {
            // Arrange
            var rooms = new List<Room>();

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act & Assert
            Assert.Throws<ModelTrainingException>(() => _modelTraining.TrainModel(_mockLayout));

            _mockLayout.VerifyAllExpectations();
        }
    }
}
