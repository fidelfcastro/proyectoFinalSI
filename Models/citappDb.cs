using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace proyectoFinalSI.Models
{
    public class citappDb : DbContext
    {
        public citappDb(string connectionString) : base(connectionString)
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public citappDb() : base("name=citapp")
        {

        }

        public static citappDb Create()
        {
            return new citappDb();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}