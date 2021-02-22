using ApplicationCore.DTOs.DeviceTypeProperty;
using System.Collections.Generic;

namespace ApplicationCore.DTOs.DeviceType
{
    public class DeviceTypeUpdateDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<DeviceTypePropertyUpdateDto> DeviceTypeProperties { get; set; }
    }
}
