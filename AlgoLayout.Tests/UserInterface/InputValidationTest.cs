using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.RhinoPlugin.UI;

namespace AlgoLayout.Tests.UserInterface
{
    [TestFixture]
    public class InputValidationTest
    {
        private IInputValidation _inputValidation;
        private ILayoutViewModel _mockLayoutViewModel;

        [SetUp]
        public void Setup()
        {
            _inputValidation = new InputValidation();  // Replace with actual InputValidation class
            _mockLayoutViewModel = MockRepository.GenerateMock<ILayoutViewModel>();
        }

        [Test]
        public void TestValidateAreaInput_Valid()
        {
            // Arrange
            _mockLayoutViewModel.Expect(m => m.Area).Return("100");

            // Act
            var result = _inputValidation.ValidateAreaInput(_mockLayoutViewModel);

            // Assert
            Assert.IsTrue(result);
            _mockLayoutViewModel.VerifyAllExpectations();
        }

        [Test]
        public void TestValidateAreaInput_Invalid()
        {
            // Arrange
            _mockLayoutViewModel.Expect(m => m.Area).Return("abc");

            // Act
            var result = _inputValidation.ValidateAreaInput(_mockLayoutViewModel);

            // Assert
            Assert.IsFalse(result);
            _mockLayoutViewModel.VerifyAllExpectations();
        }

        // Add more tests for other input fields
    }
}
