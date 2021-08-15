using AutoMapper;
using TrueDevice.Dtos.Device;
using TrueDevice.Dtos.User;
using TrueDevice.Models;

namespace TrueDevice
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<RegisterDeviceDto, Device>();
            CreateMap<Device,GetSingleDeviceDto>();
        }
        
    }
}