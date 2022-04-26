using System;
using System.Collections.Generic;

#nullable disable

namespace hospital
{
    public partial class BookAppointment
    {
        public int Id { get; set; }
        public short AppintmentId { get; set; }
        public string Service { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentMesaage { get; set; }
        public TimeSpan? AppoinmentTime { get; set; }

    }
}
