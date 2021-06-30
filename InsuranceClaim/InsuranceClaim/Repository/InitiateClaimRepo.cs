using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceClaim.Entities;
using Microsoft.Data.SqlClient;

namespace InsuranceClaim.Repository
{
    public class InitiateClaimRepo : IInsuranceClaims
    {
        private readonly PatientDBContext context;
        private readonly IInsurer _irepo;
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(InitiateClaimRepo));

        public InitiateClaimRepo(PatientDBContext context, IInsurer _Irepo)
        {
            this.context = context;
            _irepo = _Irepo;
        }


        public double CreateInsuranceClaim(InitiateClaim claim)
        {
            double amount=0.0;
            if (claim != null)
            {
                if (!CheckPatientStatus(claim))
                {
                    throw new InvalidOperationException();
                }
                if (!AddClaim(claim))
                {
                    throw new Exception();
                }
                else
                {
                    UpdatePatient(claim);
                }

                Insurer insurer = _irepo.GetInsurerByName(claim.InsurerName);
                if (insurer == null)
                    throw new NullReferenceException();
                amount = insurer.InsurerAmountLimit;
            }
            return amount;
        }

        private bool CheckPatientStatus(InitiateClaim claim)
        {
            List<Patient> patients = context.Patients.ToList();
            string status = patients.Where(p => p.PatientName == claim.PatientName).FirstOrDefault().TreatmentStatus;
            if(status.ToLower() == "completed")
            {
                return false;
            }
            return true;
        }

        private void UpdatePatient(InitiateClaim claim)
        {
            Patient p = context.Patients.Where(p => p.PatientName == claim.PatientName).FirstOrDefault();
            p.InitiateClaimId = claim.Id;
            p.TreatmentStatus = "Completed";
            p.TreatmentCommenceDate = DateTime.MinValue;
            context.SaveChanges();
        }

        public bool AddClaim(InitiateClaim claim)
        {
            if (claim != null)
            {
                context.InitiateClaims.Add(claim);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<InitiateClaim> GetAllInitiateClaims()
        {
            List<InitiateClaim> claims;
            try
            {
                claims= context.InitiateClaims.ToList();
            }
            catch(SqlException e)
            {
                _logger.Error(e.Message);
                return null;
            }
            return claims;
        }

    }
}
