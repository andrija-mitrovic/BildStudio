using ApplicationCore.Helpers;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Service
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> GetDevicesAsync();
        Task<IEnumerable<Device>> GetDevicesWithTypeAsync(PagingParams pagingParams);
        Task<Device> GetDeviceByIdAsync(int id);
        Task<Device> GetDeviceWithTypePropertyValueAsync(int id);
        Task<bool> CreateDeviceAsync(Device deviceType);
        Task<bool> UpdateDeviceAsync(Device deviceType);
        Task<bool> DeleteDeviceAsync(Device deviceType);
    }
}
