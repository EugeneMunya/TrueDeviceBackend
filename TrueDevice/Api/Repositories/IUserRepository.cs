using System.Threading.Tasks;
using TrueDevice.Api.Models;
using TrueDevice.Api.Services;

namespace TrueDevice.Api.Repositories
{
    public interface IUserRepository
    {
         Task<ServiceResponse<string>>Register(User newUser, string password);
         Task<ServiceResponse<string>>Login(string idNumber, string password);
    }
}