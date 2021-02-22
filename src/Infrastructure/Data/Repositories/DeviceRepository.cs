using ApplicationCore.Helpers;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models;
using ApplicationCore.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Device>> GetDevicesWithTypeAsync(PagingParams pagingParams)
        {
            var devices = _context.Devices.Include(x => x.DeviceType)
                                          .ThenInclude(x => x.DeviceTypeProperties)
                                          .ThenInclude(x => x.DevicePropertyValue).AsQueryable();

            DeviceSearchService deviceSearchService = new DeviceSearchService();
            var result = deviceSearchService.GetDevicesByParams(devices, pagingParams);
            
            return await PagedList<Device>.CreateAsync(result, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public async Task<Device> GetDeviceWithTypePropertyValueAsync(int id)
        {
            return await _context.Devices.Include(x => x.DeviceType.Parent)
                                         .ThenInclude(x => x.DeviceTypeProperties)
                                         .ThenInclude(x => x.DevicePropertyValue)
                                         .Include(x => x.DeviceType)
                                         .ThenInclude(x => x.DeviceTypeProperties)
                                         .ThenInclude(x => x.DevicePropertyValue).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
