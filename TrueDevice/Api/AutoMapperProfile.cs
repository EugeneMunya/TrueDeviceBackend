using AutoMapper;
using TrueDevice.Api.Dtos.Device;
using TrueDevice.Api.Dtos.User;
using TrueDevice.Api.Models;

namespace TrueDevice.Api
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