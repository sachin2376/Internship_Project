using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IpTreatment.Entities;
using IpTreatment.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IpTreatment.Repository
{
    public class SpecialistRepo:ISpecialists
    {
        //private readonly HttpClient httpClient;
        //private readonly IConfiguration config;
        private readonly PatientDBContext context;

        public SpecialistRepo(PatientDBContext context)
        {
            this.context = context;
        }

        

        public List<Specialist> GetSpecialists()
        {
            
            return context.Specialists.ToList();
        }
    }
}
