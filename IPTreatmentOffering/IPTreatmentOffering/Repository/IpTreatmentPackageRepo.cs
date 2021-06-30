using System;
using System.Collections.Generic;
using System.Linq;
using IPTreatmentOffering.Entities;
//using IPTreatmentOffering.Models;
using IPTreatmentOffering.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace IPTreatmentOffering
{
    public class IpTreatmentPackageRepo : IIpTreatmentPackages
    {
        private readonly PatientDBContext context;
        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(IpTreatmentPackageRepo));


        public IpTreatmentPackageRepo(PatientDBContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<IpTreatmentPackage> GetAllIpTreatmentPackages()
        {
            List<IpTreatmentPackage> ipTreatmentPackages;
            try
            {
                ipTreatmentPackages = context.IpTreatmentPackages.ToList();
            }
            catch(SqlException e)
            {
                logger.Error(e.Message);
                return null;
            }
            return ipTreatmentPackages;
        }

        public IpTreatmentPackage GetIpTreatmentPackage(string packagename)
        {
            try
            {
                Package package = context.Packages.Where(p => p.PackageName == packagename).First();
                if (package != null)
                {
                    IpTreatmentPackage ipTreatmentPackage = context.IpTreatmentPackages.Where(p => p.PackageId == package.PackageId).FirstOrDefault();
                    if (ipTreatmentPackage != null)
                        return ipTreatmentPackage;
                }
            }catch(InvalidOperationException e1)
            {
                logger.Error(e1.Message);
            }
            catch(SqlException e2)
            {
                logger.Error(e2.Message);
            }
            return null;

        }
    }
}
