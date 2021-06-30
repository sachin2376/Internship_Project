using System;
using System.Text.Json.Serialization;

namespace IpTreatmentManagementPortal.Entities
{

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}