using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models;

namespace Infrastructure.Data.Repositories
{
    public class DevicePropertyValueRepository : GenericRepository<DevicePropertyValue>, IDevicePropertyValueRepository
    {
        public DevicePropertyValueRepository(ApplicationDbContext context) : base(context) { }
    }
}
