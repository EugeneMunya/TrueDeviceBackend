using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrueDevice.Models
{
    public class User
    {
        public int Id{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public byte[] PasswordHash{get;set;}
        public byte[] HasSalt{get;set;}
        public string IdNumber{get;set;}
        public List<Device> Devices{get;set;}
        [Required]
        public string Role{get;set;}
    }
}