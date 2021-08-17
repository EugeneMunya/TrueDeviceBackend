using Microsoft.AspNetCore.Mvc;
using Moq;
using TrueDevice.Api.Controllers;
using TrueDevice.Api.Dtos.User;
using TrueDevice.Api.Models;
using TrueDevice.Api.Repositories;
using TrueDevice.Api.Services;
using Xunit;

namespace TrueDevice.UnitTest
{
    public class AuthControllerTests
    {
        [Fact]
        public async void Register_UserRegisterSucceed_OkResult()
        {

         var userRepositoryStub = new Mock<IUserRepository>(); 
         UserRegisterDto user = new UserRegisterDto{
             IdNumber="1234",
             FirstName="Eugene",
             LastName="Munya",
             Password="pass123"
         };
         ServiceResponse<string> response = new ServiceResponse<string>();
         userRepositoryStub.Setup(repo => repo.Register(It.IsAny<User>(),"pass123")).ReturnsAsync(response);
         var controller = new AuthController(userRepositoryStub.Object);
         IActionResult result = await controller.Register(user);

         Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Register_UserRegisterFail_BadRequestResult()
        {

         var userRepositoryStub = new Mock<IUserRepository>(); 
         UserRegisterDto user = new UserRegisterDto{
             IdNumber="1234",
             FirstName="Eugene",
             LastName="Munya",
             Password="pass123"
         };
         ServiceResponse<string> response = new ServiceResponse<string>{
             Success=false
         };
         userRepositoryStub.Setup(repo => repo.Register(It.IsAny<User>(),"pass123")).ReturnsAsync(response);
         var controller = new AuthController(userRepositoryStub.Object);
         IActionResult result = await controller.Register(user);

         Assert.IsType<BadRequestObjectResult>(result);
        }

         [Fact]
        public async void UserLogin_UserLoginSucceed_OkResult()
        {

         var userRepositoryStub = new Mock<IUserRepository>(); 
         UserLoginDto user = new UserLoginDto{
             IdNumber="1234",
             Password="pass123"
         };
         ServiceResponse<string> response = new ServiceResponse<string>();
         userRepositoryStub.Setup(repo => repo.Login(It.IsAny<string>(),"pass123")).ReturnsAsync(response);
         var controller = new AuthController(userRepositoryStub.Object);
         IActionResult result = await controller.UserLogin(user);

         Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void UserLogin_UserLoginFail_BadRequestResult()
        {

         var userRepositoryStub = new Mock<IUserRepository>(); 
         UserLoginDto user = new UserLoginDto{
             IdNumber="1234",
             Password="pass123"
         };
         ServiceResponse<string> response = new ServiceResponse<string>{
             Success=false
         };
         userRepositoryStub.Setup(repo => repo.Login(It.IsAny<string>(),"pass123")).ReturnsAsync(response);
         var controller = new AuthController(userRepositoryStub.Object);
         IActionResult result = await controller.UserLogin(user);

         Assert.IsType<BadRequestObjectResult>(result);
        }


        
        
    }
}