using System.ComponentModel.DataAnnotations;

namespace TrueDevice.Api.Models
{
    public class Device
    {
        public int Id{get;set;}
        public string DeviceName{get;set;}
        [Required]
        public string SerialNumber{get;set;}
        public string MackAddress{get;set;}
        public string Imei{get;set;}
        public string Model{get;set;}
        public User User{get;set;}

    }
}