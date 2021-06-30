using System.Collections.Generic;
using IpTreatmentManagementPortal.Context;
using System.Linq;
using IpTreatmentManagementPortal.Entities;

namespace IpTreatmentManagementPortal.Repository
{
    public class OfferingsRepo : IOfferings
    {
        private readonly PatientDBContext context;

        public OfferingsRepo(PatientDBContext context)
        {
            this.context = context;
        }

        public List<IpTreatmentPackage> GetIpTreatmentPackages()
        {
            return context.IpTreatmentPackages.ToList();

        }

        public List<Package> GetIpPackages()
        {
            return context.Packages.ToList();
        }
    }
}
