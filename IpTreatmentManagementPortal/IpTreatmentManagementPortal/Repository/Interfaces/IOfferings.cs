using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IpTreatmentManagementPortal.Entities;

namespace IpTreatmentManagementPortal.Repository
{
    public interface IOfferings
    {
        public List<IpTreatmentPackage> GetIpTreatmentPackages();
        public List<Package> GetIpPackages();

    }
}
