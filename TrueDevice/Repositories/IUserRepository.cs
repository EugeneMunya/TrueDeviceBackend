using System.Threading.Tasks;
using TrueDevice.Models;
using TrueDevice.Services;

namespace TrueDevice.Repositories
{
    public interface IUserRepository
    {
         Task<ServiceResponse<string>>Register(User newUser, string password);
         Task<ServiceResponse<string>>Login(string idNumber, string password);
    }
}