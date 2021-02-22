namespace ApplicationCore.DTOs.DevicePropertyValue
{
    public class DevicePropertyValueCreateDto
    {
        public int DeviceId { get; set; }
        public int DeviceTypePropertyId { get; set; }
        public string Value { get; set; }
    }
}
