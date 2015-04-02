using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityofLouisvilleVaccine.Models;
using UniversityofLouisvilleVaccine.DataContexts;

namespace UniversityofLouisvilleVaccine.Controllers
{
    public class VaccineNotificationController : Controller
    {
        private VaccineNotificationDB db = new VaccineNotificationDB();

        // GET: /VaccineNotification/
        public ActionResult Index()
        {
            return View(db.VaccineNotifications.ToList());
        }

        // GET: /VaccineNotification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineNotification vaccinenotification = db.VaccineNotifications.Find(id);
            if (vaccinenotification == null)
            {
                return HttpNotFound();
            }
            return View(vaccinenotification);
        }

        // GET: /VaccineNotification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VaccineNotification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="NotificationID,vaccineID,vaccineName,lotNumber,numofDoses,warning,notificationchecked")] VaccineNotification vaccinenotification)
        {
            if (ModelState.IsValid)
            {
                db.VaccineNotifications.Add(vaccinenotification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaccinenotification);
        }

        // GET: /VaccineNotification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineNotification vaccinenotification = db.VaccineNotifications.Find(id);
            if (vaccinenotification == null)
            {
                return HttpNotFound();
            }
            return View(vaccinenotification);
        }

        // POST: /VaccineNotification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NotificationID,vaccineID,vaccineName,lotNumber,numofDoses,warning,notificationchecked")] VaccineNotification vaccinenotification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccinenotification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccinenotification);
        }

        // GET: /VaccineNotification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineNotification vaccinenotification = db.VaccineNotifications.Find(id);
            if (vaccinenotification == null)
            {
                return HttpNotFound();
            }
            return View(vaccinenotification);
        }

        // POST: /VaccineNotification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccineNotification vaccinenotification = db.VaccineNotifications.Find(id);
            db.VaccineNotifications.Remove(vaccinenotification);
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
