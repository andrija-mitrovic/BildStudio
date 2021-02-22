using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDeviceRepository _devices;
        private IDeviceTypeRepository _deviceTypes;
        private IDeviceTypePropertyRepository _deviceTypeProp;
        private IDevicePropertyValueRepository _devicePropValue;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IDeviceRepository Devices
            => _devices = _devices ?? new DeviceRepository(_context);

        public IDeviceTypeRepository DeviceTypes
            => _deviceTypes = _deviceTypes ?? new DeviceTypeRepository(_context);

        public IDeviceTypePropertyRepository DeviceTypeProperties
            => _deviceTypeProp = _deviceTypeProp ?? new DeviceTypePropertyRepository(_context);

        public IDevicePropertyValueRepository DevicePropertyValue
            => _devicePropValue = _devicePropValue ?? new DevicePropertyValueRepository(_context);

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
            => _context.Dispose();
    }
}
