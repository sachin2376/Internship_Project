using System;
using System.Collections.Generic;
using System.Linq;
using IpTreatment.Entities;
using Microsoft.Data.SqlClient;

namespace IpTreatment.Repository
{
    public class PatientRepo : IPatients
    {
        private readonly PatientDBContext context;
        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PatientRepo));


        public PatientRepo(PatientDBContext Context)
        {
            context = Context;
        }

        public bool AddPatient(Patient patient)
        {
            if (patient != null)
            {
                context.Patients.Add(patient);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Patient> GetPatients()
        {
            List<Patient> list;
            try
            {
                list = context.Patients.ToList();
            }
            catch(SqlException e)
            {
                logger.Error(e.Message);
                return null;
            }
            return list;
        }
    }
}
