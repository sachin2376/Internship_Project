using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.Entities;
using IpTreatmentManagementPortal.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IpTreatmentManagementPortal.Repository
{
    public class InsurerRepo:IInsurers
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;

        public List<Insurer> Insurers { get; private set; }

        public InsurerRepo(HttpClient httpClient, IConfiguration _Config)
        {
            this.httpClient = httpClient;
            config = _Config;
        }


        public async Task<int> GetInsurers()
        {
            httpClient.DefaultRequestHeaders.Clear();
            var token = Token.JwtToken;
            if (token == null)
                throw new ArgumentNullException("User isn't authorized");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); HttpResponseMessage response = await httpClient.GetAsync(config.GetValue<string>("Mysettings:Insurer-api:getinsurers"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                Insurers = JsonConvert.DeserializeObject<List<Insurer>>(content);
            }
            else
            {
                throw new Exception();
            }
            return 1;
        }

        
    }
}
