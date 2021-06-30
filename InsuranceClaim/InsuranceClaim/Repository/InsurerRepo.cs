using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceClaim.Entities;
using Microsoft.Data.SqlClient;

namespace InsuranceClaim.Repository
{
    public class InsurerRepo : IInsurer
    {
        private readonly PatientDBContext context;
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(InsurerRepo));


        public InsurerRepo(PatientDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Insurer> GetAllInsurer()
        {
            List<Insurer> insurers;
            try
            {
                insurers = context.Insurers.ToList();
            }
            catch (SqlException e)
            {
                _logger.Error(e.Message);
                return null;
            }
            return insurers;
            
        }

        public Insurer GetInsurerByName(string name)
        {
            Insurer insurer;
            try
            {
                insurer = context.Insurers.Where(i => i.InsurerName == name).First();
            }catch(SqlException e)
            {
                _logger.Error(e.Message);
                return null;
            }
            return insurer;
        }

        public Insurer GetInsurerByPackage(string packagename)
        {
            Insurer insurer;
            try
            {
                insurer = context.Insurers.Where(i => i.InsurerPackageName == packagename).FirstOrDefault();
            }
            catch (SqlException e)
            {
                _logger.Error(e.Message);
                return null;
            }
            return insurer;
            
        }
    }
}
