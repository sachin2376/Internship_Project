using System;
using System.Collections.Generic;
using IpTreatment.Entities;

namespace IpTreatment.Repository
{
    public interface ITreatmentPlans
    {
        
        public TreatmentPlan CreateTreatmentPlan(Patient patient);
        public IEnumerable<TreatmentPlan> GetTreatmentPlans();
        public bool AddTreatmentPlan(TreatmentPlan treatmentPlan);
    }
}
