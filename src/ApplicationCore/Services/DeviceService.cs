using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Service;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            return await _unitOfWork.Devices.GetAllAsync();
        }

        public async Task<IEnumerable<Device>> GetDevicesWithTypeAsync(PagingParams pagingParams)
        {
            return await _unitOfWork.Devices.GetDevicesWithTypeAsync(pagingParams);
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            return await _unitOfWork.Devices.GetByIdAsync(id);
        }

        public async Task<Device> GetDeviceWithTypePropertyValueAsync(int id)
        {
            return await _unitOfWork.Devices.GetDeviceWithTypePropertyValueAsync(id);
        }

        public async Task<bool> CreateDeviceAsync(Device device)
        {
            await _unitOfWork.Devices.AddAsync(device);

            if (await _unitOfWork.SaveAsync())
                return true;

            return false;
        }

        public async Task<bool> UpdateDeviceAsync(Device device)
        {
            _unitOfWork.Devices.Update(device);

            if (await _unitOfWork.SaveAsync())
                return true;

            return false;
        }

        public async Task<bool> DeleteDeviceAsync(Device device)
        {
            _unitOfWork.Devices.Remove(device);

            if (await _unitOfWork.SaveAsync())
                return true;

            return false;
        }
    }
}
