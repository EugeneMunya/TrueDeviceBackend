using System.Collections.Generic;
using System.Threading.Tasks;
using TrueDevice.Api.Dtos.Device;
using TrueDevice.Api.Models;

namespace TrueDevice.Api.Services
{
    public interface IDeviceService
    {
      Task<ServiceResponse<string>> RegisterDevice(RegisterDeviceDto newDevice);
        Task<ServiceResponse<GetSingleDeviceDto>> GetDeviceById(int id);
        Task<ServiceResponse<List<Device>>> GetAllDevices();
        Task<ServiceResponse<string>> ExchangeDevice(int id, string IdNumer);
    }
}