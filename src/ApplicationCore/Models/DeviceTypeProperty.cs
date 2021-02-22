namespace ApplicationCore.Models
{
    public class DeviceTypeProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceType DeviceType { get; set; }
        public DevicePropertyValue DevicePropertyValue { get; set; }
        public int DeviceTypeId { get; set; }
    }
}
