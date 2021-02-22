using ApplicationCore.Helpers;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Service;
using ApplicationCore.Models;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace UnitTests.WebAPI.Controllers
{
    public class DeviceTypesControllerTests
    {
        private readonly Mock<IDeviceTypeService> _mockDevTypeSer;
        private readonly DeviceTypesController _deviceTypesController;
        private readonly Mock<IDeviceTypeRepository> _mockDevTypeRepo;

        public DeviceTypesControllerTests()
        {
            _mockDevTypeSer = new Mock<IDeviceTypeService>();
            _mockDevTypeRepo = new Mock<IDeviceTypeRepository>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            _deviceTypesController = new DeviceTypesController(_mockDevTypeSer.Object, mapper);
        }

        [Fact]
        public async Task GetDevice_ShouldReturnNotNull()
        {
            _mockDevTypeRepo.Setup(r => r.GetByIdAsync(1).Result).Returns(new DeviceType());
            _mockDevTypeSer.Setup(u => u.GetDeviceTypeByIdAsync(1)).ReturnsAsync(new DeviceType());

            var result = await _deviceTypesController.GetDeviceType(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDevices_ShouldReturnNotNull()
        {
            PagingParams pagingParams = new PagingParams()
            {
                PageSize = 2,
                PageNumber = 2
            };

            _mockDevTypeRepo.Setup(r => r.GetAllAsync().Result).Returns(new List<DeviceType>());
            _mockDevTypeSer.Setup(u => u.GetDeviceTypesAsync().Result).Returns(new List<DeviceType>());

            var result = await _deviceTypesController.GetDeviceTypes(pagingParams);

            Assert.NotNull(result);
        }
    }
}
