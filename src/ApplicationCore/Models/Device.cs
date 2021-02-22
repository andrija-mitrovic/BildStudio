using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }
        public int DeviceTypeId { get; set; }
        public ICollection<DevicePropertyValue> DevicePropertyValues {get;set;}
    }
}
