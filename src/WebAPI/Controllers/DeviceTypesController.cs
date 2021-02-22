using ApplicationCore.DTOs.DeviceType;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces.Service;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTypesController : ControllerBase
    {
        private readonly IDeviceTypeService _deviceTypeService;
        private readonly IMapper _mapper;

        public DeviceTypesController(
            IDeviceTypeService deviceTypeService,
            IMapper mapper)
        {
            _deviceTypeService = deviceTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Return list of device type
        /// </summary>
        //GET: api/devicetypes
        [HttpGet]
        public async Task<IActionResult> GetDeviceTypes([FromQuery] PagingParams pagingParams)
        {
            var deviceTypes = await _deviceTypeService.GetDevicesWithTypeAsync(pagingParams);
            var deviceTypesDto = _mapper.Map<List<DeviceTypeListDto>>(deviceTypes);
            
            return Ok(deviceTypesDto);
        }

        /// <summary>
        /// Find device type by id
        /// </summary>
        /// <param name="id">The ID of the desired device</param>
        //GET: api/devicetypes/1
        [HttpGet("{id}", Name = "GetDeviceType")]
        public async Task<IActionResult> GetDeviceType(int id)
        {
            var deviceType = await _deviceTypeService.GetDeviceTypeAndSubDeviceTypeWithPropertiesByIdAsync(id);
            var deviceTypeDto = _mapper.Map<DeviceTypeDetailDto>(deviceType);

            return Ok(deviceTypeDto);
        }

        /// <summary>
        /// Create device type
        /// </summary>
        /// <param name="deviceTypeCreateDto">The device type object that needs to be added</param>
        //POST: api/devicetypes
        [HttpPost]
        public async Task<IActionResult> CreateDeviceType(DeviceTypeCreateDto deviceTypeCreateDto)
        {
            var deviceType = _mapper.Map<DeviceType>(deviceTypeCreateDto);

            int? parentId = deviceTypeCreateDto.ParentId;

            if(await _deviceTypeService.CreateDeviceTypeAsync(parentId, deviceType))
            {
                var deviceTypeReturn = _mapper.Map<DeviceTypeDetailDto>(deviceType);
                return CreatedAtRoute("GetDeviceType", new { id = deviceType.Id }, deviceTypeReturn);
            }

            throw new Exception("Creating device type failed on save");
        }

        /// <summary>
        /// Update device type by id
        /// </summary>
        /// <param name="id">The ID of the desired device type</param>
        /// <param name="deviceTypeUpdateDto">The device type object that needs to be updated</param>
        //PUT: api/devicetypes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeviceType(int id, DeviceTypeUpdateDto deviceTypeUpdateDto)
        {
            var deviceType = await _deviceTypeService.GetDeviceTypeByIdAsync(id);

            if (deviceType == null)
                return NotFound();

            if (deviceTypeUpdateDto.ParentId == null)
                deviceTypeUpdateDto.ParentId = deviceType.ParentId;

            _mapper.Map(deviceTypeUpdateDto, deviceType);

            if (await _deviceTypeService.UpdateDeviceTypeAsync(deviceType))
                return NoContent();

            throw new Exception($"Updating device type {id} failed to save");
        }

        /// <summary>
        /// Delete device by id
        /// </summary>
        /// <param name="id">The ID of the desired device type</param>
        //DELETE: api/devicetypes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceType(int id)
        {
            var deviceType = await _deviceTypeService.GetDeviceTypeByIdAsync(id);

            if (deviceType == null)
                return NotFound();

            if (await _deviceTypeService.DeleteDeviceTypeAsync(deviceType))
                return NoContent();

            throw new Exception($"Deleting device type {id} failed on save");
        }
    }
}
