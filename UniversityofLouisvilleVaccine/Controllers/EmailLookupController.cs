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
    public class EmailLookupController : Controller
    {
        private EmailLookupDBContext db = new EmailLookupDBContext();

        // GET: /EmailLookup/
        public ActionResult Index()
        {
            return View(db.emaillookups.ToList());
        }

        // GET: /EmailLookup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLookup emaillookup = db.emaillookups.Find(id);
            if (emaillookup == null)
            {
                return HttpNotFound();
            }
            return View(emaillookup);
        }

        // GET: /EmailLookup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EmailLookup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,VacID,VacName,lotn,sent")] EmailLookup emaillookup)
        {
            if (ModelState.IsValid)
            {
                db.emaillookups.Add(emaillookup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emaillookup);
        }

        // GET: /EmailLookup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLookup emaillookup = db.emaillookups.Find(id);
            if (emaillookup == null)
            {
                return HttpNotFound();
            }
            return View(emaillookup);
        }

        // POST: /EmailLookup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,VacID,VacName,lotn,sent")] EmailLookup emaillookup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emaillookup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emaillookup);
        }

        // GET: /EmailLookup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLookup emaillookup = db.emaillookups.Find(id);
            if (emaillookup == null)
            {
                return HttpNotFound();
            }
            return View(emaillookup);
        }

        // POST: /EmailLookup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailLookup emaillookup = db.emaillookups.Find(id);
            db.emaillookups.Remove(emaillookup);
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
