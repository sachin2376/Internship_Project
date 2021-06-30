using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.Context;
using IpTreatmentManagementPortal.Entities;
using IpTreatmentManagementPortal.Entity;
using IpTreatmentManagementPortal.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IpTreatmentManagementPortal.Repository
{
    public class PatientRepo:IPatients
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        private readonly PatientDBContext context;

        public PatientRepo(HttpClient httpClient, IConfiguration _Config, PatientDBContext context)
        {
            this.httpClient = httpClient;
            config = _Config;
            this.context = context;
        }

        public async Task<List<Patient>> GetPatients()
        {
            List<Patient> patients = null;

            httpClient.DefaultRequestHeaders.Clear();
            var token = Token.JwtToken;
            if (token == null)
                throw new ArgumentNullException("User isn't authorized");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.GetAsync(config.GetValue<string>("Mysettings:IpTreatments-api:getpatients"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                patients = JsonConvert.DeserializeObject<List<Patient>>(content);
            }
            if(patients == null)
            {
                throw new NullReferenceException();
            }
            return patients;
        }

        
        public async Task<TreatmentPlan> FormulateTimeTable(Patient patient)
        {
            patient.Ailment = patient.Ailment.ToString();
            context.SaveChanges();
            httpClient.DefaultRequestHeaders.Clear();
            string token = Token.JwtToken;
            if (token == null)
                throw new ArgumentNullException("User isn't authorized");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(config.GetValue<string>("Mysettings:IpTreatments-Api:getTreatmentPlan")),
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(patient), Encoding.UTF8, mediaType: "application/json")
            };


            TreatmentPlan treatmentPlan = new TreatmentPlan();
            HttpResponseMessage response = await httpClient.SendAsync(request);
            _ = response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                treatmentPlan = JsonConvert.DeserializeObject<TreatmentPlan>(content);
            }
            return treatmentPlan;
        }
    }
}
