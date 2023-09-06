using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.MEPServices;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.MEPServices
{
    [TestFixture]
    public class CircuitDesignTest
    {
        private ICircuitDesign _circuitDesign;
        private IMep _mockMep;

        [SetUp]
        public void Setup()
        {
            _circuitDesign = new CircuitDesign();  // Replace with your actual CircuitDesign class
            _mockMep = MockRepository.GenerateMock<IMep>();
        }

        [Test]
        public void TestDesignCircuit()
        {
            // Arrange
            var electricalLoads = new List<ElectricalLoad> { new ElectricalLoad("Light", 100) };

            _mockMep.Expect(m => m.ElectricalLoads).Return(electricalLoads);

            // Act
            var result = _circuitDesign.DesignCircuit(_mockMep);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Designed", result.Status);  // Replace with your actual status property

            _mockMep.VerifyAllExpectations();
        }

        [Test]
        public void TestDesignCircuit_Failed()
        {
            // Arrange
            var electricalLoads = new List<ElectricalLoad>();

            _mockMep.Expect(m => m.ElectricalLoads).Return(electricalLoads);

            // Act & Assert
            Assert.Throws<CircuitDesignException>(() => _circuitDesign.DesignCircuit(_mockMep));

            _mockMep.VerifyAllExpectations();
        }
    }
}
