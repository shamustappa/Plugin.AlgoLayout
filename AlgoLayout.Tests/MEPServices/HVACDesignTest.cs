using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.MEPServices;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.MEPServices
{
    [TestFixture]
    public class HVACDesignTest
    {
        private IHVACDesign _hvacDesign;
        private IMep _mockMep;

        [SetUp]
        public void Setup()
        {
            _hvacDesign = new HVACDesign();  // Replace with your actual HVACDesign class
            _mockMep = MockRepository.GenerateMock<IMep>();
        }

        [Test]
        public void TestDesignHVAC()
        {
            // Arrange
            var thermalLoads = new List<ThermalLoad> { new ThermalLoad("Zone1", 2000) };

            _mockMep.Expect(m => m.ThermalLoads).Return(thermalLoads);

            // Act
            var result = _hvacDesign.DesignHVAC(_mockMep);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Designed", result.Status);  // Replace with your actual status property

            _mockMep.VerifyAllExpectations();
        }

        [Test]
        public void TestDesignHVAC_Failed()
        {
            // Arrange
            var thermalLoads = new List<ThermalLoad>();

            _mockMep.Expect(m => m.ThermalLoads).Return(thermalLoads);

            // Act & Assert
            Assert.Throws<HVACDesignException>(() => _hvacDesign.DesignHVAC(_mockMep));

            _mockMep.VerifyAllExpectations();
        }
    }
}
