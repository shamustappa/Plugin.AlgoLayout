using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.RhinoPlugin.UI;
using AlgoLayout.Core.Models;

namespace AlgoLayout.Tests.UserInterface
{
    [TestFixture]
    public class ButtonFunctionalityTest
    {
        private IButtonFunctionality _buttonFunctionality;
        private ILayoutViewModel _mockLayoutViewModel;

        [SetUp]
        public void Setup()
        {
            _buttonFunctionality = new ButtonFunctionality();  // Replace with actual ButtonFunctionality class
            _mockLayoutViewModel = MockRepository.GenerateMock<ILayoutViewModel>();
        }

        [Test]
        public void TestCreateButton()
        {
            // Arrange
            _mockLayoutViewModel.Expect(m => m.CreateLayout()).Return(true);

            // Act
            var result = _buttonFunctionality.CreateButton(_mockLayoutViewModel);

            // Assert
            Assert.IsTrue(result);
            _mockLayoutViewModel.VerifyAllExpectations();
        }

        [Test]
        public void TestDeleteButton()
        {
            // Arrange
            _mockLayoutViewModel.Expect(m => m.DeleteLayout()).Return(true);

            // Act
            var result = _buttonFunctionality.DeleteButton(_mockLayoutViewModel);

            // Assert
            Assert.IsTrue(result);
            _mockLayoutViewModel.VerifyAllExpectations();
        }

        // Add more tests for other buttons
    }
}
