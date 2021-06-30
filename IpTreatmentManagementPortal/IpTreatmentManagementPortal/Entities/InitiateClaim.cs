using System;
using System.Collections.Generic;

#nullable disable

namespace IpTreatmentManagementPortal.Entities
{
    public partial class InitiateClaim
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Ailment { get; set; }
        public string TreatmentPackageName { get; set; }
        public string InsurerName { get; set; }
    }
}
