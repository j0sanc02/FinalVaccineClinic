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
    public class GInfoController : Controller
    {
        private GInfoDBContext db = new GInfoDBContext();

        // GET: /GInfo/
        public ActionResult Index()
        {
            return View(db.GInfos.ToList());
        }

        // GET: /GInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GInfo ginfo = db.GInfos.Find(id);
            if (ginfo == null)
            {
                return HttpNotFound();
            }
            return View(ginfo);
        }

        // GET: /GInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,grantTitle,grantStart,grantEnd,grantAmount,grantFunder,collaborator,coordName,deadline,maxPages")] GInfo ginfo)
        {
            if (ModelState.IsValid)
            {
                db.GInfos.Add(ginfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ginfo);
        }

        // GET: /GInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GInfo ginfo = db.GInfos.Find(id);
            if (ginfo == null)
            {
                return HttpNotFound();
            }
            return View(ginfo);
        }

        // POST: /GInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,grantTitle,grantStart,grantEnd,grantAmount,grantFunder,collaborator,coordName,deadline,maxPages")] GInfo ginfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ginfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ginfo);
        }

        // GET: /GInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GInfo ginfo = db.GInfos.Find(id);
            if (ginfo == null)
            {
                return HttpNotFound();
            }
            return View(ginfo);
        }

        // POST: /GInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GInfo ginfo = db.GInfos.Find(id);
            db.GInfos.Remove(ginfo);
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
