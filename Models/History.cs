using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinalSI.Models
{
    public class History
    {
        public int historyId { get; set; }
        public int patientId { get; set; }
        public Patient patient { get; set; }
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
        public int appointmentId { get; set; }
        public Appointment appointment { get; set; }
        public DateTime date { get; set; }
        
    }
}