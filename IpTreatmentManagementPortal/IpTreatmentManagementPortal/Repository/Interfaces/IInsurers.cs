using System;
using System.Threading.Tasks;

namespace IpTreatmentManagementPortal.Repository
{
    public interface IInsurers
    {
        public Task<int> GetInsurers();
    }

}
