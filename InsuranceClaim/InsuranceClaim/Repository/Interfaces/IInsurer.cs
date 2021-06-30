using System.Collections.Generic;
using InsuranceClaim.Entities;
//using InsuranceClaim.Models;

namespace InsuranceClaim.Repository
{
    public interface IInsurer
    {

        //public static List<Insurer> insurers = new List<Insurer>
        //{
        //    new Insurer{ Id = 1000, InsurerName="LIC",InsurerPackageName="Life_insurance", InsurerAmountLimit = 225000, DisbursementDuration=30},
        //    new Insurer{ Id = 1001, InsurerName="PGR",InsurerPackageName="Gurantee_insurance", InsurerAmountLimit = 150000, DisbursementDuration=15},
        //    new Insurer{ Id = 1002, InsurerName="ALL",InsurerPackageName="Property_insurance", InsurerAmountLimit = 85000, DisbursementDuration=20},
        //    new Insurer{ Id = 1003, InsurerName="HUM",InsurerPackageName="Health_insurance", InsurerAmountLimit = 95000, DisbursementDuration=22},
        //    new Insurer{ Id = 1004, InsurerName="CNC",InsurerPackageName="Liability_insurance", InsurerAmountLimit = 102500, DisbursementDuration=21}
        //};

        public IEnumerable<Insurer> GetAllInsurer();
        public Insurer GetInsurerByName(string name);
        public Insurer GetInsurerByPackage(string packagename);
    }
}
