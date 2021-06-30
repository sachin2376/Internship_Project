using System.Collections.Generic;
using System.Linq;
using IPTreatmentOffering.Entities;
//using IPTreatmentOffering.Models;

namespace IPTreatmentOffering.Repository
{
    public class SpecialistRepo : ISpecialist
    {
        private readonly PatientDBContext context;

        public SpecialistRepo(PatientDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Specialist> GetAllSpecialists()
        {
            return context.Specialists.ToList();
        }
    }
}
