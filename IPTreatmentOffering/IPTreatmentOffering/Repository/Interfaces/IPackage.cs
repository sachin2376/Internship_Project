using System;
using System.Collections.Generic;
using IPTreatmentOffering.Entities;

namespace IPTreatmentOffering.Repository
{
    public interface IPackage
    {
        public IEnumerable<Package> GetAllPackages();
    }
}
