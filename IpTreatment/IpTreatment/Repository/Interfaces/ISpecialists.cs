using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IpTreatment.Entities;

namespace IpTreatment.Repository.Interfaces
{
    public interface ISpecialists
    {
        public List<Specialist> GetSpecialists();
    }
}
