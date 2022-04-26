using System;
using System.Collections.Generic;

#nullable disable

namespace hospital
{
    public partial class PatientRegister
    {
        //public PatientRegister()
        //{
            //BookAppointments = new HashSet<BookAppointment>();
        //}

        public short Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal? Phonenumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public virtual ICollection<BookAppointment> BookAppointments { get; set; }
        //public string Usermeassgae { get; internal set; }
    }
}
