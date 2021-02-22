using ApplicationCore.Helpers;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IDeviceTypeRepository : IGenericRepository<DeviceType>
    {
        Task<IEnumerable<DeviceType>> GetDeviceTypesWithPropertiesAsync(PagingParams pagingParams);
        Task<DeviceType> GetParentDeviceTypeAsync(int parentId);
        Task<DeviceType> GetDeviceTypeAndSubDeviceTypeWithPropertiesByIdAsync(int id);
    }
}
