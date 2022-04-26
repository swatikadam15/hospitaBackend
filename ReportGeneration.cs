using System;
using System.Collections.Generic;

#nullable disable

namespace hospital
{
    public partial class ReportGeneration
    {
        public int Id { get; set; }
        public int? ReportId { get; set; }
        public string Service { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string PatientDetails { get; set; }
        public string TreatmentDetails { get; set; }
        public string Recommendation { get; set; }
    }
}
