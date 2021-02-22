using ApplicationCore.DTOs.DeviceTypeProperty;
using System.Collections.Generic;

namespace ApplicationCore.DTOs.DeviceType
{
    public class DeviceTypeCreateDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<DeviceTypePropertyCreateDto> DeviceTypeProperties { get; set; }
    }
}
