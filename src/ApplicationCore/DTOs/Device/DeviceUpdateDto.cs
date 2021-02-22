using ApplicationCore.DTOs.DevicePropertyValue;
using System.Collections.Generic;

namespace ApplicationCore.DTOs.Device
{
    public class DeviceUpdateDto
    {
        public string Name { get; set; }
        public int DeviceTypeId { get; set; }
        public ICollection<DevicePropertyValueUpdateDto> DevicePropertyValues { get; set; }
    }
}
