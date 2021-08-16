using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrueDevice.Models
{
    public class User
    {
        public int Id{get;set;}
        [Required]
        public string FirstName{get;set;}
        [Required]
        public string LastName{get;set;}
        [Required]
        public byte[] PasswordHash{get;set;}
        [Required]
        public byte[] HasSalt{get;set;}
        [Required]
        public string IdNumber{get;set;}
        public List<Device> Devices{get;set;}
        [Required]
        public string Role{get;set;}
    }
}