using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.MachineLearning;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.MachineLearning
{
    [TestFixture]
    public class DataPreprocessingTest
    {
        private IDataPreprocessing _dataPreprocessing;
        private ILayout _mockLayout;

        [SetUp]
        public void Setup()
        {
            _dataPreprocessing = new DataPreprocessing();  // Replace with your actual DataPreprocessing class
            _mockLayout = MockRepository.GenerateMock<ILayout>();
        }

        [Test]
        public void TestNormalizeData()
        {
            // Arrange
            var room = new Room("Living Room", 100);
            var rooms = new List<Room> { room };

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act
            var result = _dataPreprocessing.NormalizeData(_mockLayout);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1.0, room.NormalizedArea);  // Replace with your actual normalized property

            _mockLayout.VerifyAllExpectations();
        }

        [Test]
        public void TestNormalizeData_Failed()
        {
            // Arrange
            var rooms = new List<Room>();

            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act & Assert
            Assert.Throws<DataNormalizationException>(() => _dataPreprocessing.NormalizeData(_mockLayout));

            _mockLayout.VerifyAllExpectations();
        }
    }
}
