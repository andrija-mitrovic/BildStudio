using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Models;

namespace Infrastructure.Data.Repositories
{
    public class DeviceTypePropertyRepository : GenericRepository<DeviceTypeProperty>, IDeviceTypePropertyRepository
    {
        public DeviceTypePropertyRepository(ApplicationDbContext context) : base(context) { }
    }
}
