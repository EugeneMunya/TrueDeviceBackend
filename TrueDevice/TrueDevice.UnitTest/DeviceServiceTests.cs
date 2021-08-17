using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using TrueDevice.Api.Data;
using TrueDevice.Api.Dtos.Device;
using TrueDevice.Api.Models;
using TrueDevice.Api.Services;
using Xunit;

namespace TrueDevice.UnitTest
{
    public class DeviceServiceTests
    {
         [Fact]
        public async void GetAllDevices_RetrieveListOfDevicesFails_GetFalseResponse()
        {
            var mockSet = new Mock<DbSet<Device>>();
            var databaseContextStub = new Mock<DataContext>();
            var httpContext = new Mock<IHttpContextAccessor>();
            var mapperStub = new Mock<IMapper>();

          databaseContextStub.Setup(c => c.Devices).Returns(mockSet.Object);
          var deviceService = new DeviceService(databaseContextStub.Object,mapperStub.Object,httpContext.Object);
          var devices = await deviceService.GetAllDevices();
          Assert.False(devices.Success);

         }

          [Fact]
        public async void GetDeviceById_RetrieveSingleDeviceFail_GetFalseResponse()
        {
            var mockSet = new Mock<DbSet<Device>>();
            var databaseContextStub = new Mock<DataContext>();
            var httpContext = new Mock<IHttpContextAccessor>();
            var mapperStub = new Mock<IMapper>();

          databaseContextStub.Setup(c => c.Devices).Returns(mockSet.Object);
          var deviceService = new DeviceService(databaseContextStub.Object,mapperStub.Object,httpContext.Object);
          var device = await deviceService.GetDeviceById(1);
          Assert.False(device.Success);

         }

           [Fact]
        public async void RegisterDevice_RegisterDeviceFail_GetFalseResponse()
        {
            var mockSet = new Mock<DbSet<Device>>();
            var databaseContextStub = new Mock<DataContext>();
            var httpContext = new Mock<IHttpContextAccessor>();
            var mapperStub = new Mock<IMapper>();
            RegisterDeviceDto deviceDto = new RegisterDeviceDto()
            {
                DeviceName="Nokia",
                SerialNumber="123",
                Model="q23w",
                Imei="23455"
            };

          databaseContextStub.Setup(c => c.Devices).Returns(mockSet.Object);
          var deviceService = new DeviceService(databaseContextStub.Object,mapperStub.Object,httpContext.Object);
          var device = await deviceService.RegisterDevice(deviceDto);
          Assert.False(device.Success);

         }

          [Fact]
        public async void ExchangeDevice_ExchangeDeviceDeviceFail_GetFalseResponse()
        {
            var mockSet = new Mock<DbSet<Device>>();
            var databaseContextStub = new Mock<DataContext>();
            var httpContext = new Mock<IHttpContextAccessor>();
            var mapperStub = new Mock<IMapper>();
          databaseContextStub.Setup(c => c.Devices).Returns(mockSet.Object);
          var deviceService = new DeviceService(databaseContextStub.Object,mapperStub.Object,httpContext.Object);
          var device = await deviceService.ExchangeDevice(1,"1234");
          Assert.False(device.Success);

         }


    }
}