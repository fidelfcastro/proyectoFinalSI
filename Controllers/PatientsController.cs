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
    public class PatientsController : Controller
    {
        private citappDb db = new citappDb();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }


        //public ActionResult ViewAppointments(int? id)
        //{
        //    //List<String> patientAppList = new List<string>();
        //    PatientAppointment pa  = new PatientAppointment();
        //    List<Object> list = new List<Object>();

        //    pa.appointmentList = db.Appointments.Where(a => a.patientId == id).Include(a => a.doctor).ToList();
        //    foreach(var n in pa.appointmentList)
        //    {
        //        pa.appointment = db.Appointments.Find(n.appointmentId);
        //    }
            
        //    //var appointments = db.Appointments.Include(a => a.doctor).Include(a => a.patient);

        //    pa.patients = db.Patients.Find(id);

        //    return View(pa);
        //}

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var y = new PatientAppointment();
            y.patients = db.Patients.Find(id);
            y.appointmentList = db.Appointments.Where(a => a.patientId == id).Include(a => a.doctor).Include(a => a.patient).ToList();
            //Patient patient = db.Patients.Find(id);
            if (y== null)
            {
                return HttpNotFound();
            }
            return View(y);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,lastName,userName,password,email")] Patient patient)
        {
            List<string> usernameList = new List<string>();
            List<string> emailList = new List<string>();
            var usernames = db.Patients.Select(a => a.userName);
            var emails = db.Patients.Select(a => a.email).ToList();

            foreach (var username in usernames)
            {
                usernameList.Add(username);
            }

            foreach (var email in emails)
            {
                emailList.Add(email);
            }

            if (usernameList.Contains(patient.userName) || emailList.Contains(patient.email))
            {
                return RedirectToAction("Create");
            }

            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,lastName,userName,password,email")] Patient patient,int? id)
        {
            List<string> usernameList = new List<string>();
            List<string> emailList = new List<string>();
            var usernames = db.Patients.Where(a => a.Id != id).Select(a => a.userName);
            var emails = db.Patients.Where(a => a.Id != id).Select(a => a.email).ToList();

            foreach (var username in usernames)
            {
                usernameList.Add(username);
            }

            foreach (var email in emails)
            {
                emailList.Add(email);
            }

            if (usernameList.Contains(patient.userName) || emailList.Contains(patient.email))
            {
                return RedirectToAction("Edit");
            }

            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
