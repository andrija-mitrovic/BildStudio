using ApplicationCore.DTOs.Device;
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
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DevicesController(
            IDeviceService deviceService,
            IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        /// <summary>
        /// Return list of devices
        /// </summary>
        //GET: api/devices
        [HttpGet]
        public async Task<IActionResult> GetDevices([FromQuery] PagingParams pagingParams)
        {
            var devices = await _deviceService.GetDevicesWithTypeAsync(pagingParams);
            var devicesDto = _mapper.Map<List<DeviceListDto>>(devices);

            return Ok(devicesDto);
        }

        /// <summary>
        /// Find device by id
        /// </summary>
        /// <param name="id">The ID of the desired device</param>
        //GET: api/devices/1
        [HttpGet("{id}", Name = "GetDevice")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var device = await _deviceService.GetDeviceWithTypePropertyValueAsync(id);
            var deviceDto = _mapper.Map<DeviceDetailDto>(device);

            return Ok(deviceDto);
        }

        /// <summary>
        /// Create device
        /// </summary>
        /// <param name="deviceCreateDto">The device object that needs to be added</param>
        //POST: api/devices
        [HttpPost]
        public async Task<IActionResult> CreateDevice(DeviceCreateDto deviceCreateDto)
        {
            var device = _mapper.Map<Device>(deviceCreateDto);

            if(await _deviceService.CreateDeviceAsync(device))
            {
                var deviceReturn = _mapper.Map<DeviceDetailDto>(device);
                return CreatedAtRoute("GetDevice", new { id = device.Id }, deviceReturn);
            }

            throw new Exception("Creating device failed on save");
        }

        /// <summary>
        /// Update device by id
        /// </summary>
        /// <param name="id">The ID of the desired device</param>
        /// <param name="deviceUpdateDto">The device object that needs to be updated</param>
        //PUT: api/devices/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(int id, DeviceUpdateDto deviceUpdateDto)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);

            if (device == null)
                return NotFound();

            _mapper.Map(deviceUpdateDto, device);

            if (await _deviceService.UpdateDeviceAsync(device))
                return NoContent();

            throw new Exception($"Updating device {id} failed to save");
        }

        /// <summary>
        /// Delete device by id
        /// </summary>
        /// <param name="id">The ID of the desired device</param>
        //DELETE: api/devices/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);

            if (device == null)
                return NotFound();

            if (await _deviceService.DeleteDeviceAsync(device))
                return NoContent();

            throw new Exception($"Deleting device {id} failed on save");
        }
    }
}
