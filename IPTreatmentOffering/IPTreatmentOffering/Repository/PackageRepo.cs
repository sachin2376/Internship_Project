using System;
using System.Collections.Generic;
using System.Linq;
using IPTreatmentOffering.Entities;
//using IPTreatmentOffering.Models;

namespace IPTreatmentOffering.Repository
{
    public class PackageRepo : IPackage
    {
        private readonly PatientDBContext context;

        public PackageRepo(PatientDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Package> GetAllPackages()
        {
        
            return context.Packages.ToList();
        }
    }
}
