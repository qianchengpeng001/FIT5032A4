using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _21S2_BZ_2.Models;

namespace _21S2_BZ_2.Controllers
{
    public class AppointmentsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointmentSet = db.AppointmentSet.Include(a => a.Patient).Include(a => a.Clinic);
            return View(appointmentSet.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.PatientSet, "Id", "f_name");
            ViewBag.ClinicId = new SelectList(db.ClinicSet, "Id", "name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,datetime,PatientId,ClinicId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentSet.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.PatientSet, "Id", "f_name", appointment.PatientId);
            ViewBag.ClinicId = new SelectList(db.ClinicSet, "Id", "name", appointment.ClinicId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.PatientSet, "Id", "f_name", appointment.PatientId);
            ViewBag.ClinicId = new SelectList(db.ClinicSet, "Id", "name", appointment.ClinicId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,datetime,PatientId,ClinicId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.PatientSet, "Id", "f_name", appointment.PatientId);
            ViewBag.ClinicId = new SelectList(db.ClinicSet, "Id", "name", appointment.ClinicId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.AppointmentSet.Find(id);
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
            Appointment appointment = db.AppointmentSet.Find(id);
            db.AppointmentSet.Remove(appointment);
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
