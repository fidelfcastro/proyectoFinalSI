﻿using System;
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
    public class AppointmentsController : Controller
    {
      
        private citappDb db = new citappDb();

        // GET: Appointments

        public ActionResult Index()
        {
            //var patientsByDoctor = db.Appointments.Join(db.Doctors, a => a.doctorId, d => d.doctorId, (a, d) => new
            //{ Appointment = a, Doctor = d }).Select(f => f.Appointment.patientId);
            var appointments = db.Appointments.Include(a => a.doctor).Include(a => a.patient);
            return View(appointments.ToList());
        }

        public ActionResult DoctorsPatients(int? id)
        {
            var patients = db.Appointments.Where(a => a.doctorId == id).Include(a => a.doctor).Include(a => a.patient);
            return View();

        }

        public ActionResult AppointmentPerPatient(int? id)
        {
            List<Appointment> appointment = new List<Appointment>();
            appointment = db.Appointments.Where(a => a.patientId == id).Include(a => a.doctor).Include(a => a.patient).ToList();

           
            return View(appointment);
        }


        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }



        // GET: Appointments/Create
        public ActionResult Create()
        {
            
            ViewBag.doctorId = new SelectList(db.Doctors, "doctorId", "speciality");
            ViewBag.patientId = new SelectList(db.Patients, "Id", "firstName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "appointmentId,patientId,doctorId,status,date,description")] Appointment appointment)
        {
            List<DateTime> dateList = new List<DateTime>();
            List<int> specialtiesList = new List<int>();
            var dateAppointment = db.Appointments.Select(a => a.date);
            var doctorInAppointment = db.Appointments.Select(a => a.doctorId).ToList();

            foreach (var dates in dateAppointment)
            {
                dateList.Add(dates);
            }

            foreach (var specialty in doctorInAppointment)
            {
                specialtiesList.Add(specialty);
            }

            if (dateList.Contains(appointment.date) && specialtiesList.Contains(appointment.doctorId))
            {
                return RedirectToAction("Create");
            }

            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctorId = new SelectList(db.Doctors, "doctorId", "speciality", appointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patients, "Id", "firstName", appointment.patientId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctorId = new SelectList(db.Doctors, "doctorId", "speciality", appointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patients, "Id", "firstName", appointment.patientId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "appointmentId,patientId,doctorId,status,date,description")] Appointment appointment, int? id)
        {
            List<DateTime> dateList = new List<DateTime>();
            List<int> specialtiesList = new List<int>();
            var dateAppointment = db.Appointments.Where(a => a.appointmentId != id).Select(a => a.date);
            var doctorInAppointment = db.Appointments.Where(a => a.appointmentId != id).Select(a => a.doctorId).ToList();

            foreach (var dates in dateAppointment)
            {
                dateList.Add(dates);
            }

            foreach (var specialty in doctorInAppointment)
            {
                specialtiesList.Add(specialty);
            }

            if (dateList.Contains(appointment.date) && specialtiesList.Contains(appointment.doctorId))
            {
                return RedirectToAction("Edit");
            }

            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctorId = new SelectList(db.Doctors, "doctorId", "speciality", appointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patients, "Id", "firstName", appointment.patientId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
