using System.Collections.Generic;
using System.Threading.Tasks;
using TrueDevice.Dtos.Device;
using TrueDevice.Models;

namespace TrueDevice.Services
{
    public interface IDeviceService
    {
      Task<ServiceResponse<string>> RegisterDevice(RegisterDeviceDto newDevice);
        Task<ServiceResponse<GetSingleDeviceDto>> GetDeviceById(int id);
        Task<ServiceResponse<List<Device>>> GetAllDevices();
    }
}