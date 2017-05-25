using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinalSI.Models
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public int patientId { get; set; }
        public Patient patient { get; set; }
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
     
    }
}