using ApplicationCore.Helpers;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Service
{
    public interface IDeviceTypeService
    {
        Task<IEnumerable<DeviceType>> GetDeviceTypesAsync();
        Task<IEnumerable<DeviceType>> GetDevicesWithTypeAsync(PagingParams pagingParams);
        Task<DeviceType> GetDeviceTypeByIdAsync(int id);
        Task<DeviceType> GetDeviceTypeAndSubDeviceTypeWithPropertiesByIdAsync(int id);
        Task<bool> CreateDeviceTypeAsync(int? parentId, DeviceType deviceType);
        Task<bool> UpdateDeviceTypeAsync(DeviceType deviceType);
        Task<bool> DeleteDeviceTypeAsync(DeviceType deviceType);
    }
}
