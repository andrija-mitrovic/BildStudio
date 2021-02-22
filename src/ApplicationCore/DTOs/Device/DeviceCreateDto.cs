using ApplicationCore.DTOs.DevicePropertyValue;
using System.Collections.Generic;

namespace ApplicationCore.DTOs.Device
{
    public class DeviceCreateDto
    {
        public string Name { get; set; }
        public int DeviceTypeId { get; set; }
        public ICollection<DevicePropertyValueCreateDto> DevicePropertyValues { get; set; }
    }
}
