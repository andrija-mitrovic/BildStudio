using ApplicationCore.DTOs.DeviceType;

namespace ApplicationCore.DTOs.Device
{
    public class DeviceDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceTypeDetailDto DeviceType { get; set; }
    }
}
