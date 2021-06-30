using System;
using System.Collections.Generic;
using System.Linq;
using IpTreatment.Entities;
using IpTreatment.Repository.Interfaces;
//using IpTreatment.Service;

namespace IpTreatment.Repository
{
    public class TreatmentPlanRepo:ITreatmentPlans
    {
        private readonly IOfferings _orepo;
        private readonly SpecialistRepo _srepo;
        private readonly PatientDBContext context;
        private readonly IPatients _prepo;
        

        public TreatmentPlanRepo(IOfferings _Orepo, SpecialistRepo _Srepo,PatientDBContext context,IPatients _Prepo)
        {
            _orepo = _Orepo;
            _srepo = _Srepo;
            this.context = context;
            _prepo = _Prepo;
        }


        public TreatmentPlan CreateTreatmentPlan(Patient patient)
        {
            bool result = VerifyPatientTreatmentStartDate(patient);
            if (!result)
            {
                throw new InvalidOperationException("Commence date must be greater than current");
            }
            TreatmentPlan treatmentPlan = GetTreatmentPlan(patient);
            patient.TreatmentPlanId = treatmentPlan.Id;
            patient.TreatmentStatus = "Inprogress";
            patient.InitiateClaimId = null;
            _ = context.SaveChanges();
            if (!_prepo.AddPatient(patient))
            {
                return null;
            }

            if (!AddTreatmentPlan(treatmentPlan))
            {
                return null;
            }
            
            return treatmentPlan;
        }

        private bool VerifyPatientTreatmentStartDate(Patient patient)
        {
            if (patient.TreatmentCommenceDate.Date > DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }

        private TreatmentPlan GetTreatmentPlan(Patient patient)
        {
            TreatmentPlan treatmentPlan = new()
            {
                Id = GetNextId()
            };
            Package package = GetPackage(patient.TreatmentpackageName);
            if (package == null)
                throw new NullReferenceException();
            treatmentPlan.PackageName = package.PackageName;
            treatmentPlan.PackageName = patient.TreatmentpackageName;
            treatmentPlan.TestDetails = package.TestDetails;
            treatmentPlan.Cost = package.Cost;
            treatmentPlan.TreatmentCommencementDate = patient.TreatmentCommenceDate;
            treatmentPlan.TreatmentEnddate = treatmentPlan.TreatmentCommencementDate.AddDays(package.Duration * 7);

            treatmentPlan.SpecialistName = GetSpecialist(patient).Name;
            if (treatmentPlan.SpecialistName == null)
                throw new NullReferenceException();
            return treatmentPlan;
        }

        private string GetNextId()
        {
            var plans = from c in context.TreatmentPlans.ToList()
                                 orderby c.Id ascending
                                 select c;

            TreatmentPlan plan = plans.Last();
            int id = Int32.Parse(plan.Id.Substring(1));
            string NextId = "T" + (id + 1).ToString();
            return NextId;
        }




        public IEnumerable<TreatmentPlan> GetTreatmentPlans()
        {
            return context.TreatmentPlans.ToList();
        }



        private Package GetPackage(string PackageName)
        {
            List<Package> packages = _orepo.GetPackages();
            Package package = packages.Where(p => p.PackageName == PackageName).FirstOrDefault();
            return package;
        }


        public bool AddTreatmentPlan(TreatmentPlan treatmentPlan)
        {
            if (treatmentPlan != null)
            {
                context.TreatmentPlans.Add(treatmentPlan);
                _ = context.SaveChanges();
                return true;
            }
            return false;
        }


        private Specialist GetSpecialist(Patient patient)
        {
            Specialist specialist;
            var specialistlist = from c in _srepo.GetSpecialists()
                                 where c.AreaOfExpertise == patient.Ailment
                                 orderby c.AreaOfExpertise ascending
                                 select c;

            Package package = GetPackage(patient.TreatmentpackageName);
            if (package.Cost > 15000)
            {
                specialist = specialistlist.Last();
            }
            else if (package.Cost >= 10000)
            {
                specialist = specialistlist.ToList()[specialistlist.Count() - 2];
            }
            else if (package.Cost >= 5000)
            {
                specialist = specialistlist.ToList()[specialistlist.Count() - 3];
            }
            else
            {
                specialist = specialistlist.First();
            }

            return specialist;
        }
    }
}
