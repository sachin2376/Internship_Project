using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.Entities;
using IpTreatmentManagementPortal.Entity;
using IpTreatmentManagementPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IpTreatmentManagementPortal.Repository
{
    public class InitiateClaimsRepo:IInsuranceClaims
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        

        public List<InitiateClaim> InitiateClaims { get; private set; }

        public InitiateClaimsRepo(HttpClient httpClient, IConfiguration _config)
        {
            this.httpClient = httpClient;
            config = _config;
        }

        public async Task<int> GetInitiateClaims()
        {
            httpClient.DefaultRequestHeaders.Clear();
            var token = Token.JwtToken;
            if (token == null)
                throw new ArgumentNullException("User isn't authorized");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); HttpResponseMessage response = await httpClient.GetAsync(config.GetValue<string>("Mysettings:Insurer-api:getinsuranceclaims"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                InitiateClaims = JsonConvert.DeserializeObject<List<InitiateClaim>>(content);
            }

            else
            {
                throw new Exception();
            }
            return 1;
        }

        public InitiateClaim CreateClaim(Patient patient)
        {
            InitiateClaim claim = new()
            {
                PatientName = patient.PatientName,
                TreatmentPackageName = patient.TreatmentpackageName,
                Ailment = patient.Ailment
            };
            return claim;
        }

        public async Task<Double> AddClaim(InitiateClaim claim,HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Clear();
            var token = Token.JwtToken;
            if (token == null)
                throw new ArgumentNullException("User isn't authorized");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //HttpResponseMessage response = await httpClient.GetAsync(config.GetValue<string>("Mysettings:Insurer-api:getinsurers"));
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(config.GetValue<string>("Mysettings:Insurer-api:postinitiateclaim"), claim);
            double result=0.0;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Double>(content);
                Console.WriteLine(" Result : " + result);
            }
            else
            {
                throw new Exception();
            }
            return result;
        }
    }
}
