using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;  // Replace with your actual namespace
using AlgoLayout.Core.SafetyProtocols;  // Replace with your actual namespace
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.SafetyProtocols
{
    [TestFixture]
    public class EmergencyExitTest
    {
        private IEmergencyExit _emergencyExit;
        private IRoom _mockRoom;

        [SetUp]
        public void Setup()
        {
            _emergencyExit = new EmergencyExit();  // Replace with your actual EmergencyExit class
            _mockRoom = MockRepository.GenerateMock<IRoom>();
        }

        [Test]
        public void TestDesignEmergencyExit()
        {
            // Arrange
            var exits = new List<Exit> { new Exit("Exit1", "North") };

            _mockRoom.Expect(r => r.Exits).Return(exits);

            // Act
            var result = _emergencyExit.DesignEmergencyExit(_mockRoom);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Designed", result.Status);  // Replace with your actual status property

            _mockRoom.VerifyAllExpectations();
        }

        [Test]
        public void TestDesignEmergencyExit_Failed()
        {
            // Arrange
            var exits = new List<Exit>();

            _mockRoom.Expect(r => r.Exits).Return(exits);

            // Act & Assert
            Assert.Throws<EmergencyExitException>(() => _emergencyExit.DesignEmergencyExit(_mockRoom));

            _mockRoom.VerifyAllExpectations();
        }
    }
}
