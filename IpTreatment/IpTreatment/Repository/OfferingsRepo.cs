using System;
using System.Collections.Generic;
using System.Linq;
using IpTreatment.Entities;
using IpTreatment.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace IpTreatment.Repository
{
    public class OfferingsRepo:IOfferings
    {
        //private readonly HttpClient httpClient;
        //private readonly IConfiguration config;
        private readonly PatientDBContext context;
        private readonly ILogger<OfferingsRepo> logger;

        
        public OfferingsRepo(PatientDBContext Context,ILogger<OfferingsRepo> logger)
        {
            this.context = Context;
            this.logger = logger;
        }


        public List<IpTreatmentPackage> GetIpTreatmentPackages()
        {
            List<IpTreatmentPackage> packages;
            try
            {
                packages = context.IpTreatmentPackages.ToList();
            }catch(Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }

            return packages;
        }

        public List<Package> GetPackages()
        {
            List<Package> packages;
            try
            {
                packages = context.Packages.ToList();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }

            return packages;
        }
    }
}
