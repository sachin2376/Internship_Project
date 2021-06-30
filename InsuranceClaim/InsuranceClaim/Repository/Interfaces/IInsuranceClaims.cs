using System.Collections.Generic;
using InsuranceClaim.Entities;

namespace InsuranceClaim.Repository
{
    public interface IInsuranceClaims
    {
        
        public IEnumerable<InitiateClaim> GetAllInitiateClaims();
        public double CreateInsuranceClaim(InitiateClaim claim);
        public bool AddClaim(InitiateClaim claim);
    }
}
