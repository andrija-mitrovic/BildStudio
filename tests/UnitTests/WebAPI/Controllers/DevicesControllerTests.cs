using ApplicationCore.Helpers;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Service;
using AutoMapper;
using Moq;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace UnitTests.WebAPI.Controllers
{
    public class DevicesControllerTests
    {
        private readonly Mock<IDeviceService> _mockDevSer;
        private readonly DevicesController _devicesController;
        private readonly Mock<IDeviceRepository> _mockDevRepo;

        public DevicesControllerTests()
        {
            _mockDevSer = new Mock<IDeviceService>();
            _mockDevRepo = new Mock<IDeviceRepository>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            _devicesController = new DevicesController(_mockDevSer.Object, mapper);
        }

        [Fact]
        public async Task GetDevice_ShouldReturnNotNull()
        {
            var result = await _devicesController.GetDevice(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDevices_ShouldReturnNotNull()
        {
            PagingParams pagingParams = new PagingParams()
            {
                PageSize = 2
            };

            var result = await _devicesController.GetDevices(pagingParams);

            Assert.NotNull(result);
        }
    }
}
