using System;
using System.Collections.Generic;

#nullable disable

namespace InsuranceClaim.Entities
{
    public partial class Specialist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AreaOfExpertise { get; set; }
        public int ExpInYears { get; set; }
        public string ContactNumber { get; set; }
    }
}
