using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TrueDevice.Data;
using TrueDevice.Dtos.Device;
using TrueDevice.Models;

namespace TrueDevice.Services
{
    public class DeviceService : IDeviceService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeviceService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor=httpContextAccessor;
            _context=context;
            _mapper=mapper;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<List<Device>>> GetAllDevices()
        {
            ServiceResponse<List<Device>> response = new ServiceResponse<List<Device>>();
            List<Device> devices = await _context.Devices.Where(device => device.User.Id==GetUserId()).ToListAsync();
            response.Data=devices;

            return response;
        }

        public async Task<ServiceResponse<GetSingleDeviceDto>> GetDeviceById(int id)
        {
            ServiceResponse<GetSingleDeviceDto> response = new ServiceResponse<GetSingleDeviceDto>();
            Device device = await _context.Devices.FirstAsync(device =>device.Id==id && device.User.Id==GetUserId());
            response.Data= _mapper.Map<GetSingleDeviceDto>(device);
            return response;
        }

        public async Task<ServiceResponse<string>> RegisterDevice(RegisterDeviceDto newDevice)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
           try
           {
             Device device = (_mapper.Map<Device>(newDevice));
            User owner = await _context.Users.FirstOrDefaultAsync(user => user.Id==GetUserId());
            if(owner==null)
            {
                response.Success=false;
                response.Message="User not found";
                return response;
            }
            device.User=owner;
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
            response.Data= device.SerialNumber;
           }
           catch (System.Exception ex)
           {
                response.Success=false;
                response.Message=ex.Message;
           }
            return response;
        }
    }
}