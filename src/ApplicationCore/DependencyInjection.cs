using ApplicationCore.Interfaces.Service;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static void AddApplicationCore(this IServiceCollection services)
        {
            services.ConfigureInjection();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void ConfigureInjection(this IServiceCollection services)
        {
            services.AddScoped<IDeviceTypeService, DeviceTypeService>();
            services.AddScoped<IDeviceService, DeviceService>();
        }
    }
}
