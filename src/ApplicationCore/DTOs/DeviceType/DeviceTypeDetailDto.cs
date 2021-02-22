using ApplicationCore.DTOs.DeviceTypeProperty;
using System.Collections.Generic;

namespace ApplicationCore.DTOs.DeviceType
{
    public class DeviceTypeDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceTypeListDto Parent { get; set; }
        public ICollection<DeviceTypePropertyListDto> DeviceTypeProperties { get; set; }
    }
}
