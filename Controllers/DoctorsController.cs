using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyectoFinalSI.Models;

namespace proyectoFinalSI.Controllers
{
    public class DoctorsController : Controller
    {
        private citappDb db = new citappDb();

        // GET: Doctors
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }

       

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = new PatientAppointment();
            x.doctors = db.Doctors.Find(id);
            x.patientsPerDoctorList = db.Appointments.Where(a => a.doctorId == id).Include(a => a.patient).Include(a => a.doctor).ToList();
            //Patient patient = db.Patients.Find(id);
            if (x == null)
            {
                return HttpNotFound();
            }
            return View(x);

            //Doctor doctor = db.Doctors.Find(id);
            //if (doctor == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "doctorId,speciality,firstName,lastName,userName,password,email")] Doctor doctor)
        {
            List<string> usernameList = new List<string>();
            List<string> emailList = new List<string>();
            var usernames = db.Doctors.Select(a => a.userName);
            var emails = db.Doctors.Select(a => a.email).ToList();

            foreach (var username in usernames)
            {
                usernameList.Add(username);
            }

            foreach (var email in emails)
            {
                emailList.Add(email);
            }

            if (usernameList.Contains(doctor.userName) || emailList.Contains(doctor.email))
            {
                return RedirectToAction("Create");
            }

            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "doctorId,speciality,firstName,lastName,userName,password,email")] Doctor doctor, int? id)
        {
            List<string> usernameList = new List<string>();
            List<string> emailList = new List<string>();
            var usernames = db.Doctors.Where(a => a.doctorId != id).Select(a => a.userName);
            var emails = db.Doctors.Where(a => a.doctorId != id).Select(a => a.email).ToList();

            foreach (var username in usernames)
            {
                usernameList.Add(username);
            }

            foreach (var email in emails)
            {
                emailList.Add(email);
            }

            if (usernameList.Contains(doctor.userName) || emailList.Contains(doctor.email))
            {
                return RedirectToAction("Edit");
            }

            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

     
    }
}
