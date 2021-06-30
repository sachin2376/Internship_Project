using System;
using System.Collections.Generic;

#nullable disable

namespace IpTreatmentManagementPortal.Entities
{
    public partial class Package
    {
        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public int Duration { get; set; }
    }
}
