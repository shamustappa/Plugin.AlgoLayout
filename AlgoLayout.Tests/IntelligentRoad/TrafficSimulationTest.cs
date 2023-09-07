using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.IntelligentRoad;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.IntelligentRoad
{
    [TestFixture]
    public class TrafficSimulationTest
    {
        private ITrafficSimulation _trafficSimulation;
        private IMap _mockMap;

        [SetUp]
        public void Setup()
        {
            _trafficSimulation = new TrafficSimulation();  // Replace with actual TrafficSimulation class
            _mockMap = MockRepository.GenerateMock<IMap>();
        }

        [Test]
        public void TestSimulateTraffic()
        {
            // Arrange
            var vehicles = new List<Vehicle> { new Vehicle("Car", 60) };

            _mockMap.Expect(m => m.Vehicles).Return(vehicles);

            // Act
            var result = _trafficSimulation.SimulateTraffic(_mockMap);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Simulated", result.Status);  // Replace with actual status property

            _mockMap.VerifyAllExpectations();
        }

        [Test]
        public void TestSimulateTraffic_Failed()
        {
            // Arrange
            var vehicles = new List<Vehicle>();

            _mockMap.Expect(m => m.Vehicles).Return(vehicles);

            // Act & Assert
            Assert.Throws<TrafficSimulationException>(() => _trafficSimulation.SimulateTraffic(_mockMap));

            _mockMap.VerifyAllExpectations();
        }
    }
}
