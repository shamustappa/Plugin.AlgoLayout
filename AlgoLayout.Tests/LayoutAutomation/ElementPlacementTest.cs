using AlgoLayout.Core.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgoLayout.Tests.LayoutAutomation
{
    internal class ElementPlacementTest
    {
    }
}
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.Core.Models;  // Replace with your actual namespace
using AlgoLayout.Core.Algorithms;  // Replace with your actual namespace

namespace AlgoLayout.Tests.LayoutAutomation
{
    [TestFixture]
    public class ElementPlacementTest
    {
        private IElementPlacement _elementPlacement;
        private ILayout _mockLayout;

        [SetUp]
        public void Setup()
        {
            _elementPlacement = new ElementPlacement();  // Replace with your actual ElementPlacement class
            _mockLayout = MockRepository.GenerateMock<ILayout>();
        }

        [Test]
        public void TestPlaceElement()
        {
            // Arrange
            var element = new Element("Chair");
            var room = new Room("Living Room");
            var elements = new List<Element> { element };
            var rooms = new List<Room> { room };

            _mockLayout.Expect(l => l.Elements).Return(elements);
            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act
            var result = _elementPlacement.PlaceElement(_mockLayout, element, room);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(room, element.Room);

            _mockLayout.VerifyAllExpectations();
        }

        [Test]
        public void TestPlaceElement_Failed()
        {
            // Arrange
            var element = new Element("Chair");
            var room = new Room("Living Room");
            var elements = new List<Element>();
            var rooms = new List<Room> { room };

            _mockLayout.Expect(l => l.Elements).Return(elements);
            _mockLayout.Expect(l => l.Rooms).Return(rooms);

            // Act & Assert
            Assert.Throws<ElementPlacementException>(() => _elementPlacement.PlaceElement(_mockLayout, element, room));

            _mockLayout.VerifyAllExpectations();
        }
    }
}
