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
        public ActionResult Index(string sortby)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortby) ? "Name desc" : "";
            ViewBag.gNameSort = sortby == "gName" ? "gName desc" : "gName";
            ViewBag.EndDateSort = sortby == "end date" ? "end date desc" : "end date";
            ViewBag.AmountSort = sortby == "amount" ? "amount desc" : "amount";
            ViewBag.SponsorSort = sortby == "sponsor" ? "sponsor desc" : "sponsor";
            ViewBag.CoordNameSort = sortby == "coord name" ? "coord name desc" : "coord name";
            ViewBag.DeadlineSort = sortby == "deadline" ? "deadline desc" : "deadline";

            var grants = from a in db.GInfos select a;
            switch (sortby)
            {
                case "Name desc":
                    grants = grants.OrderByDescending(s => s.grantTitle);
                    break;
                case "Name":
                    grants = grants.OrderBy(s => s.grantTitle);
                    break;
                case "gName desc":
                    grants = grants.OrderByDescending(s => s.grantTitle);
                    break;
                case "gName":
                    grants = grants.OrderBy(s => s.grantTitle);
                    break;
                case "end date":
                    grants = grants.OrderBy(s => s.grantEnd);
                    break;
                case "end date desc":
                    grants = grants.OrderByDescending(s => s.grantEnd);
                    break;
                case "amount":
                    grants = grants.OrderBy(s => s.grantAmount);
                    break;
                case "amount desc":
                    grants = grants.OrderByDescending(s => s.grantAmount);
                    break;
                case "sponsor":
                    grants = grants.OrderBy(s => s.grantFunder);
                    break;
                case "sponsor desc":
                    grants = grants.OrderByDescending(s => s.grantFunder);
                    break;
                case "coord name":
                    grants = grants.OrderBy(s => s.coordName);
                    break;
                case "coord name desc":
                    grants = grants.OrderByDescending(s => s.coordName);
                    break;
                case "deadline":
                    grants = grants.OrderBy(s => s.deadline);
                    break;
                case "deadline desc":
                    grants = grants.OrderByDescending(s => s.deadline);
                    break;
                default:
                    grants = grants.OrderBy(s => s.grantTitle);
                    break;
            }

            return View(grants);
            
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
