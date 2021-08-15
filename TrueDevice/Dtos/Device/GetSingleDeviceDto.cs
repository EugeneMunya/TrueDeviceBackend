namespace TrueDevice.Dtos.Device
{
    public class GetSingleDeviceDto
    {
        public string DeviceName{get;set;}
        public string SerialNumber{get;set;}
        public string MackAddress {get;set;}
        public string Imei {get;set;}
        public string Model{get;set;}
    }
}