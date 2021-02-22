using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Services
{
    public class DeviceTypeServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnit;
        private readonly DeviceTypeService _deviceTypeService;

        public DeviceTypeServiceTests()
        {
            _mockUnit = new Mock<IUnitOfWork>();
            _deviceTypeService = new DeviceTypeService(_mockUnit.Object);
        }

        [Fact]
        public async Task GetDeviceTypes_ShouldReturnNotEqual()
        {
            _mockUnit.Setup(u => u.DeviceTypes.GetAllAsync()).ReturnsAsync(new List<DeviceType>());

            var result = await _deviceTypeService.GetDeviceTypesAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDeviceType_ShouldReturnNotEqual()
        {
            _mockUnit.Setup(u => u.DeviceTypes.GetByIdAsync(1)).ReturnsAsync(new DeviceType());

            var result = await _deviceTypeService.GetDeviceTypeByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDeviceTypesByParams_ShouldReturnNotEqual()
        {
            PagingParams pagingParams = new PagingParams()
            {
                PageSize = 2,
                PageNumber = 2
            };

            _mockUnit.Setup(u => u.DeviceTypes.GetAllAsync()).ReturnsAsync(new List<DeviceType>());

            var result = await _deviceTypeService.GetDevicesWithTypeAsync(pagingParams);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteDeviceType_ShouldReturnTrue()
        {
            _mockUnit.Setup(u => u.DeviceTypes.GetByIdAsync(15)).ReturnsAsync(new DeviceType());

            DeviceType deviceType = await _deviceTypeService.GetDeviceTypeByIdAsync(15);
            var result = await _deviceTypeService.DeleteDeviceTypeAsync(deviceType);

            Assert.True(result);
        }
    }
}
