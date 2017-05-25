using proyectoFinalSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinalSI
{
    public class PatientAppointment
    {

        public Appointment appointment = new Appointment();
        public Patient patients = new Patient();
        public Doctor doctors = new Doctor();
        public List<Appointment> appointmentList = new List<Appointment>();
        public List<Appointment> patientsPerDoctorList = new List<Appointment>();
    }
}