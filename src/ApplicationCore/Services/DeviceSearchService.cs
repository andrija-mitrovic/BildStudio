using ApplicationCore.Helpers;
using ApplicationCore.Models;
using System;
using System.Linq;

namespace ApplicationCore.Services
{
    public class DeviceSearchService
    {
        public IQueryable<Device> GetDevicesByParams(IQueryable<Device> devices, PagingParams pagingParams)
        {
            if (!string.IsNullOrEmpty(pagingParams.DeviceName))  //search devices by name
                devices = devices.Where(x => x.Name == pagingParams.DeviceName);

            if (!string.IsNullOrEmpty(pagingParams.DeviceType)) //search devices by type name
                devices = devices.Where(x => x.DeviceType.Name == pagingParams.DeviceType); 

            if (!string.IsNullOrEmpty(pagingParams.DeviceTypeProperty)) //search devices by device type property name
                devices = devices.Where(x => x.DeviceType.DeviceTypeProperties
                    .Any(u => u.Name.Contains(pagingParams.DeviceTypeProperty)));

            if (!string.IsNullOrEmpty(pagingParams.DevicePropertyValue)) //search devices by device type property value
                devices = devices.Where(x => x.DeviceType.DeviceTypeProperties
                    .Any(u => u.DevicePropertyValue.Value.Contains(pagingParams.DevicePropertyValue)));

            if (pagingParams.MinDevicePropertyValue != 0 || pagingParams.MaxDevicePropertyValue != 0) //search devices by min and max device property value
                devices = devices.Where(x => x.DevicePropertyValues.Any(u =>
                    Convert.ToInt32(u.Value) >= pagingParams.MinDevicePropertyValue ||
                    Convert.ToInt32(u.Value) <= pagingParams.MaxDevicePropertyValue));

            return devices;
        }
    }
}
