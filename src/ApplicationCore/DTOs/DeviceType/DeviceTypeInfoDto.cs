using ApplicationCore.DTOs.DeviceTypeProperty;
using System.Collections.Generic;

namespace ApplicationCore.DTOs.DeviceType
{
    public class DeviceTypeInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DeviceTypePropertyInfoDto> DeviceTypeProperties { get; set; }
    }
}
