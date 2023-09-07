using NUnit.Framework;
using Rhino.Mocks;
using AlgoLayout.RhinoPlugin.CloudIntegration;
namespace AlgoLayout.Tests.CloudIntegration
{
    [TestFixture]
    public class DataSyncTest
    {
        private IDataSync _dataSync;
        private ICloudService _mockCloudService;

        [SetUp]
        public void Setup()
        {
            _dataSync = new DataSync();  // Replace with actual DataSync class
            _mockCloudService = MockRepository.GenerateMock<ICloudService>();
        }

        [Test]
        public void TestSyncLayoutData_Success()
        {
            // Arrange
            var layoutData = new LayoutData { /* populate with test data */ };
            _mockCloudService.Expect(m => m.UploadLayoutData(layoutData)).Return(true);

            // Act
            var result = _dataSync.SyncLayoutData(layoutData, _mockCloudService);

            // Assert
            Assert.IsTrue(result);
            _mockCloudService.VerifyAllExpectations();
        }

        [Test]
        public void TestSyncLayoutData_Failure()
        {
            // Arrange
            var layoutData = new LayoutData { /* populate with test data */ };
            _mockCloudService.Expect(m => m.UploadLayoutData(layoutData)).Return(false);

            // Act
            var result = _dataSync.SyncLayoutData(layoutData, _mockCloudService);

            // Assert
            Assert.IsFalse(result);
            _mockCloudService.VerifyAllExpectations();
        }

        // Add more tests for other data synchronization functionalities
    }
}
