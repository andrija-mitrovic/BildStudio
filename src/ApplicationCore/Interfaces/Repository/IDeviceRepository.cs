using ApplicationCore.Helpers;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Task<IEnumerable<Device>> GetDevicesWithTypeAsync(PagingParams pagingParams);
        Task<Device> GetDeviceWithTypePropertyValueAsync(int id);
    }
}
