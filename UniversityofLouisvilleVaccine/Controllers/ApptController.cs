using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityofLouisvilleVaccine.DataContexts;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.App_Start.Controllers
{
    
    public class ApptController : Controller
    {
         ApptDBContext db = new ApptDBContext();

        // GET: /Appt/
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Index()
        {
            return View(db.Appointments.ToList());
        }

        // GET: /Appt/Details/5
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
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

        // GET: /Appt/Create
       // [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Appt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Create([Bind(Include="id,title,start,hour,min,end,allDay")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        // GET: /Appt/Create
        //[Authorize(Roles = "Admin, Executive, ProgramStaff, Patient")]
        public ActionResult PatientCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Admin, Executive, ProgramStaff, Patient")]
        public ActionResult PatientCreate([Bind(Include = "id,title,start,hour,min,end,allDay")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                //ViewBag.Message = "Appointment Scheduled";
                //return View();
                return RedirectToAction("Index", "Index");
            }

            return View(appointment);
        }

        // GET: /Appt/Edit/5
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
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
            return View(appointment);
        }

        // POST: /Appt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Edit([Bind(Include="id,title,start,hour,min,end,allDay")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: /Appt/Delete/5
       // [Authorize(Roles = "Admin, Executive, ProgramStaff")]
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

        // POST: /Appt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
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

        //get list of Appointments today on page load
        //public ActionResult ReverseCalendar()
        //{
        //    ApptDBContext db = new ApptDBContext();
        //    Appointment ap = new Appointment();

        //    string datestart = DateTime.Today.ToString();

        //    var query =
        //        from APT in db.Appointments
        //        where APT.start == datestart
        //        select APT;

        //    List<Appointment> listofappt = new List<Appointment>();

        //    foreach (Appointment cp in query)
        //    {
        //        listofappt.Add(cp);
        //    }

        //    return View(listofappt);
        //}

        //get list of Appointments today after button click
        public ActionResult ReverseCalendar(string start)
        {

            ViewBag.date = DateTime.Today;
            
            //Appointment appointment = db.Appointments.Find(start);

            return View(db.Appointments.ToList());


        }

        public ActionResult revcal(string start)
        {
            ViewBag.date = start;

            return View(db.Appointments.ToList());
        }


    }
}
