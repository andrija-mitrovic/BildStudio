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
    public class DeviceServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnit;
        private readonly DeviceService _deviceService;

        public DeviceServiceTests()
        {
            _mockUnit = new Mock<IUnitOfWork>();
            _deviceService = new DeviceService(_mockUnit.Object);
        }

        [Fact]
        public async Task GetDevices_ShouldReturnNotEqual()
        {
            _mockUnit.Setup(u => u.Devices.GetAllAsync()).ReturnsAsync(new List<Device>());

            var result = await _deviceService.GetDevicesAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDevice_ShouldReturnNotEqual()
        {
            _mockUnit.Setup(u => u.Devices.GetByIdAsync(1)).ReturnsAsync(new Device());

            var result = await _deviceService.GetDeviceByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDevicesByParams_ShouldReturnNotEqual()
        {
            PagingParams pagingParams = new PagingParams()
            {
                PageSize = 2,
                PageNumber = 2
            };

            _mockUnit.Setup(u => u.Devices.GetAllAsync()).ReturnsAsync(new List<Device>());

            var result = await _deviceService.GetDevicesWithTypeAsync(pagingParams);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteDevice_ShouldReturnTrue()
        {
            _mockUnit.Setup(u => u.Devices.GetAllAsync()).ReturnsAsync(new List<Device>());

            Device device = await _deviceService.GetDeviceByIdAsync(16);
            var result = await _deviceService.DeleteDeviceAsync(device);

            Assert.True(result);
        }
    }
}
