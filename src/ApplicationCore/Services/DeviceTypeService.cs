using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Service;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeviceTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DeviceType>> GetDeviceTypesAsync()
        {
            return await _unitOfWork.DeviceTypes.GetAllAsync();
        }

        public async Task<IEnumerable<DeviceType>> GetDevicesWithTypeAsync(PagingParams pagingParams)
        {
            return await _unitOfWork.DeviceTypes.GetDeviceTypesWithPropertiesAsync(pagingParams);
        }

        public async Task<DeviceType> GetDeviceTypeByIdAsync(int id)
        {
            return await _unitOfWork.DeviceTypes.GetByIdAsync(id);
        }

        public async Task<DeviceType> GetDeviceTypeAndSubDeviceTypeWithPropertiesByIdAsync(int id)
        {
            return await _unitOfWork.DeviceTypes.GetDeviceTypeAndSubDeviceTypeWithPropertiesByIdAsync(id);
        }

        public async Task<bool> CreateDeviceTypeAsync(int? parentId, DeviceType deviceType)
        {
            if (parentId == null)
                await _unitOfWork.DeviceTypes.AddAsync(deviceType);
            else
            {
                DeviceType parentDeviceType = await _unitOfWork.DeviceTypes.GetParentDeviceTypeAsync((int)parentId);
                parentDeviceType.Children.Add(deviceType);
            }

            if (await _unitOfWork.SaveAsync())
                return true;

            return false;
        }

        public async Task<bool> UpdateDeviceTypeAsync(DeviceType deviceType)
        {
            _unitOfWork.DeviceTypes.Update(deviceType);

            if (await _unitOfWork.SaveAsync())
                return true;

            return false;
        }

        public async Task<bool> DeleteDeviceTypeAsync(DeviceType deviceType)
        {
            _unitOfWork.DeviceTypes.Remove(deviceType);

            if (await _unitOfWork.SaveAsync())
                return true;

            return false;
        }
    }
}
