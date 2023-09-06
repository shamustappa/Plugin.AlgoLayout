using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;  // Replace with your actual namespace
using AlgoLayout.Core.SafetyProtocols;  // Replace with your actual namespace
using AlgoLayout.Core.Interfaces;
using System.Security.Claims;

namespace AlgoLayout.Tests.SafetyProtocols
{
    [TestFixture]
    public class SafetyAlertTest
    {
        private ISafetyAlert _safetyAlert;
        private IRoom _mockRoom;

        [SetUp]
        public void Setup()
        {
            _safetyAlert = new SafetyAlert();  // Replace with your actual SafetyAlert class
            _mockRoom = MockRepository.GenerateMock<IRoom>();
        }

        [Test]
        public void TestDesignSafetyAlert()
        {
            // Arrange
            var alarms = new List<Alarm> { new Alarm("SmokeAlarm", "Ceiling") };

            _mockRoom.Expect(r => r.Alarms).Return(alarms);

            // Act
            var result = _safetyAlert.DesignSafetyAlert(_mockRoom);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Designed", result.Status);  // Replace with your actual status property

            _mockRoom.VerifyAllExpectations();
        }

        [Test]
        public void TestDesignSafetyAlert_Failed()
        {
            // Arrange
            var alarms = new List<Alarm>();

            _mockRoom.Expect(r => r.Alarms).Return(alarms);

            // Act & Assert
            Assert.Throws<SafetyAlertException>(() => _safetyAlert.DesignSafetyAlert(_mockRoom));

            _mockRoom.VerifyAllExpectations();
        }
    }
}
