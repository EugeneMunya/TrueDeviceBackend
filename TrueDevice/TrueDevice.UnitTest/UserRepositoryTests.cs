using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using TrueDevice.Api.Data;
using TrueDevice.Api.Models;
using TrueDevice.Api.Repositories;
using TrueDevice.Api.Services;
using Xunit;

namespace TrueDevice.UnitTest
{
    public class UserRepositoryTests
    {
        [Fact]
        public async void Register_UserRegisterSucceed_GetTrueResult()
        {
            var mockSet = new Mock<DbSet<User>>();
            var databaseContextStub = new Mock<DataContext>();
            var configurationStub = new Mock<IConfiguration>();
            var mapperStub = new Mock<IMapper>();
             User user = new User{
             IdNumber="123489",
             FirstName="Eugene",
             LastName="Munya",
             PasswordHash= new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
             HasSalt= new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
         };
          databaseContextStub.Setup(c => c.Users).Returns(mockSet.Object);
          var userRepository = new UserRepository(databaseContextStub.Object,configurationStub.Object,mapperStub.Object);
          var register = await userRepository.Register(user,"pass123");
          Assert.IsType<ServiceResponse<string>>(register);

         }

          [Fact]
        public async void Login_UserLogiFail_GetFalseResult()
        {
            var mockSet = new Mock<DbSet<User>>();
            var databaseContextStub = new Mock<DataContext>();
            var configurationStub = new Mock<IConfiguration>();
            var mapperStub = new Mock<IMapper>();

          databaseContextStub.Setup(c => c.Users).Returns(mockSet.Object);
          var userRepository = new UserRepository(databaseContextStub.Object,configurationStub.Object,mapperStub.Object);
          var login = await userRepository.Login("12345","pass123");
          Assert.False(login.Success);

         }

        }
    }
