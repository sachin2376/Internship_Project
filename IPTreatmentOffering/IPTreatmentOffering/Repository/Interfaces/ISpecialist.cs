
using System.Collections.Generic;
using IPTreatmentOffering.Entities;

namespace IPTreatmentOffering.Repository
{
    public interface ISpecialist
    {
        public IEnumerable<Specialist> GetAllSpecialists();
    }
}
