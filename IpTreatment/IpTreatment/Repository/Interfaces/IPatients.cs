using System;
using System.Collections.Generic;
using IpTreatment.Entities;

namespace IpTreatment.Repository
{
    public interface IPatients
    {
        public IEnumerable<Patient> GetPatients();
        public bool AddPatient(Patient patient);
    }
}
