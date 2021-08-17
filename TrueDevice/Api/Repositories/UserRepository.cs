using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrueDevice.Api.Data;
using TrueDevice.Api.Models;
using TrueDevice.Api.Services;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace TrueDevice.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserRepository(DataContext context, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _context=context;
            _mapper=mapper;
        }
        public async Task<ServiceResponse<string>> Register(User newUser, string password)
        {
          ServiceResponse<string> response = new ServiceResponse<string>();
          try
          {
              if(await UserExists(newUser.IdNumber))
               {
                   response.Success=false;
                   response.Message="User already exisit";
                   return response;
                }
                 CreateHashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);
                 newUser.PasswordHash= passwordHash;
                 newUser.HasSalt= passwordSalt;
                 await _context.Users.AddAsync(newUser);
                 await _context.SaveChangesAsync();
                 response.Data=CreateToken(newUser);
          }
          catch (System.Exception ex)
          {
               response.Success=false;
               response.Message=ex.Message;
          }
         
          return response;
        }
        public async Task<ServiceResponse<string>> Login(string idNumber, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                 User user = await _context.Users.FirstOrDefaultAsync(user => user.IdNumber==idNumber);
                 if(user==null)
                 {
                      response.Success=false;
                      response.Message="User not found";
                      return response;
                }
                if(!VerifyPasswordHash(password,user.PasswordHash,user.HasSalt))
                {
                     response.Success=false;
                     response.Message="Wrong credentials";
                     return response;
                 }
                 response.Data=CreateToken(user);
                
            }
            catch (System.Exception ex)
            {
                 response.Success=false;
                 response.Message=ex.Message;
            }
           

            return response;
        }

        private void CreateHashPassword(string password,out byte[]passwordHash ,out byte[]passwordSalt)
        {
            using( var hmc = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmc.Key;
                passwordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        private bool VerifyPasswordHash(string password, byte[]passwordHash,byte[]passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i=0;i<computedHash.Length;i++)
                {
                    if(computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.PostalCode, user.IdNumber)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<bool> UserExists(string userIdNumber)
        {
            if(await _context.Users.AnyAsync(user => user.IdNumber==userIdNumber))
            {
                return true;
            }
            return false;
        }

    }
}