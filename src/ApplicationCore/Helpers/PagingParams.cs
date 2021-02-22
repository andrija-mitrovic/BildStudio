namespace ApplicationCore.Helpers
{
    public class PagingParams
    {
        public int pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string DevicePropertyValue { get; set; }
        public string DeviceTypeProperty { get; set; }
        public int MinDevicePropertyValue { get; set; }
        public int MaxDevicePropertyValue { get; set; }
    }
}
