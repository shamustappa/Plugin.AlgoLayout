using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;  // Replace with your actual namespace
using AlgoLayout.Core.SafetyProtocols;  // Replace with your actual namespace
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.SafetyProtocols
{
    [TestFixture]
    public class FireSafetyTest
    {
        private IFireSafety _fireSafety;
        private IRoom _mockRoom;

        [SetUp]
        public void Setup()
        {
            _fireSafety = new FireSafety();  // Replace with your actual FireSafety class
            _mockRoom = MockRepository.GenerateMock<IRoom>();
        }

        [Test]
        public void TestDesignFireSafety()
        {
            // Arrange
            var fireExtinguishers = new List<FireExtinguisher> { new FireExtinguisher("TypeA", 2) };

            _mockRoom.Expect(r => r.FireExtinguishers).Return(fireExtinguishers);

            // Act
            var result = _fireSafety.DesignFireSafety(_mockRoom);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Designed", result.Status);  // Replace with your actual status property

            _mockRoom.VerifyAllExpectations();
        }

        [Test]
        public void TestDesignFireSafety_Failed()
        {
            // Arrange
            var fireExtinguishers = new List<FireExtinguisher>();

            _mockRoom.Expect(r => r.FireExtinguishers).Return(fireExtinguishers);

            // Act & Assert
            Assert.Throws<FireSafetyException>(() => _fireSafety.DesignFireSafety(_mockRoom));

            _mockRoom.VerifyAllExpectations();
        }
    }
}
