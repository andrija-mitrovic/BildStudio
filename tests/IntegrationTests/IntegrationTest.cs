using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using WebAPI;

namespace IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient testClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                    {
                        builder.ConfigureServices(services =>
                        {
                            services.RemoveAll(typeof(ApplicationDbContext));
                            services.AddDbContext<ApplicationDbContext>(optionsAction: options => { options.UseInMemoryDatabase(databaseName: "BildStudioDB"); });
                        });
                    });
            testClient = appFactory.CreateClient();
        }
    }
}
