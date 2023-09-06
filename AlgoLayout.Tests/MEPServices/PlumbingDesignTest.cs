using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;
using AlgoLayout.Core.MEPServices;
using AlgoLayout.Core.Interfaces;

namespace AlgoLayout.Tests.MEPServices
{
    [TestFixture]
    public class PlumbingDesignTest
    {
        private IPlumbingDesign _plumbingDesign;
        private IMep _mockMep;

        [SetUp]
        public void Setup()
        {
            _plumbingDesign = new PlumbingDesign();  // Replace with your actual PlumbingDesign class
            _mockMep = MockRepository.GenerateMock<IMep>();
        }

        [Test]
        public void TestDesignPlumbing()
        {
            // Arrange
            var waterLoads = new List<WaterLoad> { new WaterLoad("Sink", 10) };

            _mockMep.Expect(m => m.WaterLoads).Return(waterLoads);

            // Act
            var result = _plumbingDesign.DesignPlumbing(_mockMep);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Designed", result.Status);  // Replace with your actual status property

            _mockMep.VerifyAllExpectations();
        }

        [Test]
        public void TestDesignPlumbing_Failed()
        {
            // Arrange
            var waterLoads = new List<WaterLoad>();

            _mockMep.Expect(m => m.WaterLoads).Return(waterLoads);

            // Act & Assert
            Assert.Throws<PlumbingDesignException>(() => _plumbingDesign.DesignPlumbing(_mockMep));

            _mockMep.VerifyAllExpectations();
        }
    }
}
