using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.Entities;

namespace IpTreatmentManagementPortal.Repository
{
    public interface IPatients
    {
        public Task<List<Patient>> GetPatients();
        public Task<TreatmentPlan> FormulateTimeTable(Patient patient);
    }
}
