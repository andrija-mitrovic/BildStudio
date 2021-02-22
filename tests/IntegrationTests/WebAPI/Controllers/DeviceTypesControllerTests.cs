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
    public class DeviceTypesControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetDeviceTypes_ShouldReturnOkResponse()
        {
            var response = await testClient.GetAsync(requestUri: "/api/DeviceTypes");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetDeviceType_ReturnOkResponse()
        {
            var response = await testClient.GetAsync(requestUri: "/api/DeviceTypes/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateDeviceType_ShouldReturnCreatedResponse()
        {
            var response = await testClient.PostAsync(requestUri: "/api/DeviceTypes",
                new StringContent(JsonConvert.SerializeObject(new DeviceType()
                {
                    Name = "Racunar",
                    ParentId = 1
                }),
                Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdateDeviceType_ShouldReturnNoContentResponse()
        {
            var response = await testClient.PutAsync(requestUri: "/api/DeviceTypes/4",
                new StringContent(JsonConvert.SerializeObject(new DeviceType()
                {
                    Name = "Racunar++",
                    ParentId = 1
                }),
                Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteDeviceType_ShouldReturnNoContentResponse()
        {
            var response = await testClient.DeleteAsync(requestUri: "/api/DeviceTypes/7");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
