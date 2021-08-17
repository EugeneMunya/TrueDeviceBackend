using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TrueDevice.Api.Controllers;
using TrueDevice.Api.Dtos.Device;
using TrueDevice.Api.Models;
using TrueDevice.Api.Services;
using Xunit;

namespace TrueDevice.UnitTest
{
    public class DeviceControllerTests
    {

        
        [Fact]
        public async void RegisterNewDevice_RegisterFail_BadRequestResult()
        {
            //Arange
           
            var deviceServiceStub = new Mock<IDeviceService>();
            RegisterDeviceDto device = new RegisterDeviceDto{
                DeviceName="Nokia",
                SerialNumber="123",
                Model="q23w",
                Imei="23455"
            };
            ServiceResponse<string> response = new ServiceResponse<string>{
                Success=false
            };
            deviceServiceStub.Setup(service => service.RegisterDevice(It.IsAny<RegisterDeviceDto>())).ReturnsAsync(response);
            var controller = new DeviceController(deviceServiceStub.Object);

            //Act

            IActionResult result = await controller.RegisterNewDevice(device);

            //Asser
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void RegisterNewDevice_RegisterSucceed_GetOkResult()
        {
            //Arange
           
            var deviceServiceStub = new Mock<IDeviceService>();
            RegisterDeviceDto device = new RegisterDeviceDto{
                DeviceName="Nokia",
                SerialNumber="123",
                Model="q23w",
                Imei="23455"
            };
            ServiceResponse<string> response = new ServiceResponse<string>();
            deviceServiceStub.Setup(service => service.RegisterDevice(It.IsAny<RegisterDeviceDto>())).ReturnsAsync(response);
            var controller = new DeviceController(deviceServiceStub.Object);

            //Act

            IActionResult result = await controller.RegisterNewDevice(device);

            //Asser
            Assert.IsType<OkObjectResult>(result);
        }

            [Fact]
        public async void GetDeviceById_RetrieveFail_GetBadRequestResult()
        {
            //Arange
           
            var deviceServiceStub = new Mock<IDeviceService>();
            ServiceResponse<GetSingleDeviceDto> response = new ServiceResponse<GetSingleDeviceDto>{
                Success=false
            };
            deviceServiceStub.Setup(service => service.GetDeviceById(It.IsAny<int>())).ReturnsAsync(response);
            var controller = new DeviceController(deviceServiceStub.Object);

            //Act

            IActionResult result = await controller.GetDeviceById(2);

            //Asser
            Assert.IsType<BadRequestObjectResult>(result);
        }

             [Fact]
        public async void GetDeviceById_RetrieveSucceed_GetOkRequestResult()
        {
            //Arange
           
            var deviceServiceStub = new Mock<IDeviceService>();
            ServiceResponse<GetSingleDeviceDto> response = new ServiceResponse<GetSingleDeviceDto>();
            deviceServiceStub.Setup(service => service.GetDeviceById(It.IsAny<int>())).ReturnsAsync(response);
            var controller = new DeviceController(deviceServiceStub.Object);

            //Act

            IActionResult result = await controller.GetDeviceById(2);

            //Asser
            Assert.IsType<OkObjectResult>(result);
        }

             [Fact]
        public async void GetAllDevices_RetrieveAllSucceed_GetOkRequestResult()
        {
            //Arange
           
            var deviceServiceStub = new Mock<IDeviceService>();
            ServiceResponse<List<Device>> response = new ServiceResponse<List<Device>>();
            deviceServiceStub.Setup(service => service.GetAllDevices()).ReturnsAsync(response);
            var controller = new DeviceController(deviceServiceStub.Object);

            //Act

            IActionResult result = await controller.GetAllDevices();

            //Asser
            Assert.IsType<OkObjectResult>(result);
        }

            [Fact]
        public async void GetAllDevices_RetrieveAllFail_GetBadRequestResult()
        {
            //Arange
           
            var deviceServiceStub = new Mock<IDeviceService>();
            ServiceResponse<List<Device>> response = new ServiceResponse<List<Device>>{
                Success=false
            };
            deviceServiceStub.Setup(service => service.GetAllDevices()).ReturnsAsync(response);
            var controller = new DeviceController(deviceServiceStub.Object);

            //Act

            IActionResult result = await controller.GetAllDevices();

            //Asser
            Assert.IsType<BadRequestObjectResult>(result);
        }

            [Fact]
        public async void ExchangeDevice_ExchangeSucceed_OkRequestResult()
        {
            //Arange
           
            var deviceServiceStub = new Mock<IDeviceService>();
            ServiceResponse<string> response = new ServiceResponse<string>();
            deviceServiceStub.Setup(service => service.ExchangeDevice(It.IsAny<int>(),"1234")).ReturnsAsync(response);
            var controller = new DeviceController(deviceServiceStub.Object);

            //Act

            IActionResult result = await controller.ExchangeDevice(2,"1234");

            //Asser
            Assert.IsType<OkObjectResult>(result);
        }

            [Fact]
        public async void ExchangeDevice_ExchangeFail_BadRequestResult()
        {
            //Arange
           
            var deviceServiceStub = new Mock<IDeviceService>();
            ServiceResponse<string> response = new ServiceResponse<string>{Success=false};
            deviceServiceStub.Setup(service => service.ExchangeDevice(It.IsAny<int>(),"1234")).ReturnsAsync(response);
            var controller = new DeviceController(deviceServiceStub.Object);

            //Act

            IActionResult result = await controller.ExchangeDevice(2,"1234");

            //Asser
            Assert.IsType<BadRequestObjectResult>(result);
        }



    }
}
