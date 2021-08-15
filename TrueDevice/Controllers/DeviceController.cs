using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrueDevice.Dtos.Device;
using TrueDevice.Models;
using TrueDevice.Services;

namespace TrueDevice.Controllers
{
    [Authorize(Roles ="User")]
    [ApiController]
    [Route("[controller]")]
    public class DeviceController:ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService=deviceService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewDevice(RegisterDeviceDto newDevice)
        {
            ServiceResponse<string> response = await _deviceService.RegisterDevice(newDevice);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            ServiceResponse<GetSingleDeviceDto> response = await _deviceService.GetDeviceById(id);
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDevices()
        {
            ServiceResponse<List<Device>> response = await _deviceService.GetAllDevices();
            return Ok(response);
        }

        
    }
}