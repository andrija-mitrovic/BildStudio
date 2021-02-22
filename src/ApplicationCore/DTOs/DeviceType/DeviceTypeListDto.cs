using ApplicationCore.DTOs.DevicePropertyValue;
using ApplicationCore.DTOs.DeviceTypeProperty;
using System.Collections.Generic;

namespace ApplicationCore.DTOs.DeviceType
{
    public class DeviceTypeListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DeviceTypePropertyListDto> DeviceTypeProperties { get; set; }
    }
}
