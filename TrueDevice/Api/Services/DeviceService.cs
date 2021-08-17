using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TrueDevice.Api.Data;
using TrueDevice.Api.Dtos.Device;
using TrueDevice.Api.Models;

namespace TrueDevice.Api.Services
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
            try
            {
                List<Device> devices = await _context.Devices.Where(device => device.User.Id==GetUserId()).ToListAsync();
                response.Data=devices;
                
            }
            catch (System.Exception ex)
            {
                 response.Success=false;
                 response.Message=ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetSingleDeviceDto>> GetDeviceById(int id)
        {
            ServiceResponse<GetSingleDeviceDto> response = new ServiceResponse<GetSingleDeviceDto>();
            try
            {
                 Device device = await _context.Devices.FirstAsync(device =>device.Id==id && device.User.Id==GetUserId());
                 response.Data= _mapper.Map<GetSingleDeviceDto>(device);
            }
            catch (System.Exception ex)
            {
                 response.Success=false;
                 response.Message=ex.Message;
            }
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
        public async Task<ServiceResponse<string>> ExchangeDevice(int id, string IdNumer)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                Device device = await _context.Devices.FirstAsync(device =>device.Id==id && device.User.Id==GetUserId());
                User user = await _context.Users.FirstOrDefaultAsync(user => user.IdNumber==IdNumer);
                if(user==null)
                {
                    response.Success=false;
                    response.Message="User not found";
                    return response;
                }
                device.User = user;
                _context.Devices.Update(device);
                await _context.SaveChangesAsync();
                response.Data=device.SerialNumber;
                response.Message=$"For now {user.FirstName} is the owner of {device.SerialNumber} device";
                
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