using ApplicationCore.DTOs.DevicePropertyValue;

namespace ApplicationCore.DTOs.DeviceTypeProperty
{
    public class DeviceTypePropertyInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DevicePropertyValueInfoDto DevicePropertyValue { get; set; }
    }
}
