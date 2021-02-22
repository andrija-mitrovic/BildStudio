using ApplicationCore.Helpers;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class DeviceTypeRepository : GenericRepository<DeviceType>, IDeviceTypeRepository
    {
        public DeviceTypeRepository(ApplicationDbContext context) : base(context) { }

        public async Task<DeviceType> GetParentDeviceTypeAsync(int parentId)
        {
            return await _context.DeviceTypes.Include(x => x.Children).Where(x => x.Id == parentId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DeviceType>> GetDeviceTypesWithPropertiesAsync(PagingParams pagingParams)
        {
            var deviceTypes = _context.DeviceTypes.Include(x => x.DeviceTypeProperties).AsQueryable();

            return await PagedList<DeviceType>.CreateAsync(deviceTypes, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public async Task<DeviceType> GetDeviceTypeAndSubDeviceTypeWithPropertiesByIdAsync(int id)
        {
            return await _context.DeviceTypes.Include(x => x.Parent)
                                             .ThenInclude(x => x.DeviceTypeProperties)
                                             .Include(x => x.Children)
                                             .Include(x => x.DeviceTypeProperties)
                                             .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
