using ApplicationCore.Helpers;
using ApplicationCore.Models;
using ApplicationCore.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.ApplicationCore.Services
{
    public class DeviceSearchServiceTests
    {
        private readonly List<Device> _devicesList;
        private readonly PagingParams _pagingParams;

        public DeviceSearchServiceTests()
        {
            _devicesList = new List<Device>()
            {
                new Device()
                {
                    Name = "HP",
                    DeviceType=new DeviceType()
                    {
                        Name="Racunar"
                    }
                },
                new Device()
                {
                    Name = "Dell",
                    DeviceType = new DeviceType()
                    {
                        Name="Racunar"
                    }
                }
            };

            _pagingParams = new PagingParams()
            {
                DeviceType = "Laptop"
            };
        }

        [Fact]
        public void GetDevicesByParams_ShouldReturnEqual()
        {     
            PagingParams pagingParams = new PagingParams()
            {
                DeviceType = "Racunar"
            };

            var deviceSearchService = new DeviceSearchService();
            var devices = deviceSearchService.GetDevicesByParams(_devicesList.AsQueryable(), pagingParams);

            Assert.Equal(2, devices.Count());
        }

        [Fact]
        public void GetDevicesByParams_ShouldReturnNotEqual()
        {
            PagingParams pagingParams = new PagingParams()
            {
                DeviceType = "Laptop"
            };

            var deviceSearchService = new DeviceSearchService();
            var devices = deviceSearchService.GetDevicesByParams(_devicesList.AsQueryable(), pagingParams);

            Assert.NotEqual(2, devices.Count());
        }
    }
}
