using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrueDevice.Dtos.User;
using TrueDevice.Models;
using TrueDevice.Repositories;
using TrueDevice.Services;

namespace TrueDevice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            User user = new User{
                FirstName=request.FirstName,
                LastName=request.LastName,
                IdNumber = request.IdNumber,
            };
            ServiceResponse<string> response = await _userRepository.Register(user,request.Password);
            return Ok(response);            
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(UserLoginDto request)
        {
            ServiceResponse<string> response = await _userRepository.Login(request.IdNumber,request.Password);
            return Ok(response);
        }

        
    }
}