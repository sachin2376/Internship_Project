using System;
namespace IpTreatmentManagementPortal.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token{ get; set; }
    }
}
