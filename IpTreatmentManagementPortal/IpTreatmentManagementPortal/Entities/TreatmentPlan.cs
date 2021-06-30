using System;
using System.Collections.Generic;

#nullable disable

namespace IpTreatmentManagementPortal.Entities
{
    public partial class TreatmentPlan
    {
        public string Id { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public string SpecialistName { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
        public DateTime TreatmentEnddate { get; set; }
    }
}
