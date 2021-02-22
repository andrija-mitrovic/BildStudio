using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class DeviceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Device> Devices { get; set; }
        public DeviceType Parent { get; set; }
        public int? ParentId { get; set; }
        public ICollection<DeviceType> Children { get; set; }
        public ICollection<DeviceTypeProperty> DeviceTypeProperties { get; set; }
    }
}
