using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinalSI.Models
{
    public class Doctor
    {
        public int doctorId { get; set; }
        public string speciality { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}