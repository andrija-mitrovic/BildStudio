using ApplicationCore.DTOs.Device;
using ApplicationCore.DTOs.DevicePropertyValue;
using ApplicationCore.DTOs.DeviceType;
using ApplicationCore.DTOs.DeviceTypeProperty;
using ApplicationCore.Models;
using AutoMapper;

namespace ApplicationCore.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Device mapping
            CreateMap<DeviceCreateDto, Device>();
            CreateMap<DeviceUpdateDto, Device>();
            CreateMap<Device, DeviceDetailDto>();
            CreateMap<Device, DeviceListDto>();

            //DeviceType mapping
            CreateMap<DeviceTypeCreateDto, DeviceType>();
            CreateMap<DeviceTypeUpdateDto, DeviceType>();
            CreateMap<DeviceType, DeviceTypeListDto>();
            CreateMap<DeviceType, DeviceTypeDetailDto>();
            CreateMap<DeviceType, DeviceTypeInfoDto>();

            //DeviceTypeProperty mapping
            CreateMap<DeviceTypePropertyCreateDto, DeviceTypeProperty>();
            CreateMap<DeviceTypePropertyUpdateDto, DeviceTypeProperty>();
            CreateMap<DeviceTypeProperty, DeviceTypePropertyDetailDto>();
            CreateMap<DeviceTypeProperty, DeviceTypePropertyInfoDto>();
            CreateMap<DeviceTypeProperty, DeviceTypePropertyListDto>();

            //DevicePropertyValue mapping
            CreateMap<DevicePropertyValue, DevicePropertyValueDetailDto>();
            CreateMap<DevicePropertyValue, DevicePropertyValueListDto>();
            CreateMap<DevicePropertyValue, DevicePropertyValueInfoDto>();
            CreateMap<DevicePropertyValueCreateDto, DevicePropertyValue>();
            CreateMap<DevicePropertyValueUpdateDto, DevicePropertyValue>();
        }
    }
}
