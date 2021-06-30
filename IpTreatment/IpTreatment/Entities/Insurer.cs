using System;
using System.Collections.Generic;

#nullable disable

namespace IpTreatment.Entities
{
    public partial class Insurer
    {
        public int Id { get; set; }
        public string InsurerName { get; set; }
        public string InsurerPackageName { get; set; }
        public double InsurerAmountLimit { get; set; }
        public int DisbursementDuration { get; set; }
    }
}
