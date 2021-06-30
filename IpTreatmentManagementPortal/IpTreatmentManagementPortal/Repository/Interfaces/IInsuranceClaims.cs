using System;
using System.Net.Http;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.Entities;


namespace IpTreatmentManagementPortal.Repository
{
    public interface IInsuranceClaims
    {
        public Task<int> GetInitiateClaims();
        public InitiateClaim CreateClaim(Patient patient);
        public Task<Double> AddClaim(InitiateClaim claim,HttpClient httpClient);
    }
}
