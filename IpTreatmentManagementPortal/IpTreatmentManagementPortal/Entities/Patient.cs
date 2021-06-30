using System;
using System.Collections.Generic;

#nullable disable

namespace IpTreatmentManagementPortal.Entities
{
    public partial class Patient
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string Ailment { get; set; }
        public string TreatmentpackageName { get; set; }
        public DateTime TreatmentCommenceDate { get; set; }
        public string TreatmentStatus { get; set; }
        public int? InitiateClaimId { get; set; }
        public string TreatmentPlanId { get; set; }
    }
}
