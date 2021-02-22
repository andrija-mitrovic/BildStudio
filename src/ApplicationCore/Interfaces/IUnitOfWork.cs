using ApplicationCore.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDeviceRepository Devices { get; }
        IDeviceTypeRepository DeviceTypes { get; }
        IDeviceTypePropertyRepository DeviceTypeProperties { get; }
        IDevicePropertyValueRepository DevicePropertyValue { get; }
        Task<bool> SaveAsync();
    }
}
