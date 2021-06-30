using System.Collections.Generic;
using IPTreatmentOffering.Entities;

namespace IPTreatmentOffering.Repository
{
    public interface IIpTreatmentPackages
    {
        public IEnumerable<IpTreatmentPackage> GetAllIpTreatmentPackages();
        public IpTreatmentPackage GetIpTreatmentPackage(string packagename);
    }
}
