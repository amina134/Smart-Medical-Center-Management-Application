using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilabcsharp
{

    public class Appointment
    {
        public int AppointmentId { get; set; }  // Make sure this exists
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; }
        public string Specialty { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}