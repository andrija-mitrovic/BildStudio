namespace ApplicationCore.Models
{
    public class DevicePropertyValue
    {
        public int Id { get; set; }
        public DeviceTypeProperty DeviceTypeProperty { get; set; }
        public int DeviceTypePropertyId { get; set; }
        public Device Device { get; set; }
        public int DeviceId { get; set; }
        public string Value { get; set; }
    }
}
