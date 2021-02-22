using ApplicationCore.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.WebAPI.Controllers
{
    public class DevicesControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetDevices_ShouldReturnOkResponse()
        {
            var response = await testClient.GetAsync(requestUri: "/api/Devices");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetDevice_ShouldReturnOkResponse()
        {
            var response = await testClient.GetAsync(requestUri: "/api/Devices/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateDevice_ShouldReturnCreatedResponse()
        {
            var response = await testClient.PostAsync(requestUri: "/api/Devices", 
                new StringContent(JsonConvert.SerializeObject(new Device() 
                {
                    Name = "NOA",
                    DeviceTypeId = 1
                }), 
                Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdateDevice_ShouldReturnNoContentResponse()
        {
            var response = await testClient.PutAsync(requestUri: "/api/Devices/4",
                new StringContent(JsonConvert.SerializeObject(new Device()
                {
                    Name = "IPad++",
                    DeviceTypeId = 8
                }),
                Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteDevice_ShouldReturnNoContentResponse()
        {
            var response = await testClient.DeleteAsync(requestUri: "/api/Devices/7");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
