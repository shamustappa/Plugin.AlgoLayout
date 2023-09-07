using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.RhinoPlugin.UI;

namespace AlgoLayout.Tests.UserInterface
{
    [TestFixture]
    public class NavigationTest
    {
        private INavigation _navigation;
        private ILayoutViewModel _mockLayoutViewModel;

        [SetUp]
        public void Setup()
        {
            _navigation = new Navigation();  // Replace with actual Navigation class
            _mockLayoutViewModel = MockRepository.GenerateMock<ILayoutViewModel>();
        }

        [Test]
        public void TestNavigateToHome()
        {
            // Arrange
            _mockLayoutViewModel.Expect(m => m.CurrentPage).Return("Layout");

            // Act
            var result = _navigation.NavigateToHome(_mockLayoutViewModel);

            // Assert
            Assert.AreEqual("Home", result);
            _mockLayoutViewModel.VerifyAllExpectations();
        }

        [Test]
        public void TestNavigateToSettings()
        {
            // Arrange
            _mockLayoutViewModel.Expect(m => m.CurrentPage).Return("Home");

            // Act
            var result = _navigation.NavigateToSettings(_mockLayoutViewModel);

            // Assert
            Assert.AreEqual("Settings", result);
            _mockLayoutViewModel.VerifyAllExpectations();
        }

        // Add more tests for other navigation functionalities
    }
}
