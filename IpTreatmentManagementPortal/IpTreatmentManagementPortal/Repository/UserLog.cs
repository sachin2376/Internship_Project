using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.Entity;
using IpTreatmentManagementPortal.Models;
using IpTreatmentManagementPortal.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IpTreatmentManagementPortal.Repository
{
    public class UserLog:IUserLog
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;

        public UserLog(HttpClient httpClient,IConfiguration _Config)
        {
            this.httpClient = httpClient;
            config = _Config;
        }
        
        public async Task<Boolean> Login(UserModel userModel)
        {
            var response = await httpClient.PostAsJsonAsync(config.GetValue<string>("Mysettings:Login-url"), userModel);
            AuthenticateResponse resp = new AuthenticateResponse();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                resp = JsonConvert.DeserializeObject<AuthenticateResponse>(content);
                Token.User = resp.Username;
                Token.JwtToken = resp.Token;
                return true;
            }
            else
                throw new Exception();
        }

        public bool Logout()
        {
            if (Token.User != null)
            {
                Token.JwtToken = null;
                Token.User = null;
                return true;
            }
            return false;
            
        }
    }
}
