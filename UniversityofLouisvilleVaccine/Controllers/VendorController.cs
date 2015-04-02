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
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace UniversityofLouisvilleVaccine.Controllers
{
    public class VendorController : Controller
    {
        private VendorDBContext db = new VendorDBContext();

        // GET: /Vendor/
        public ActionResult Index(string sstring)
        {
            var vendor = from ve in db.Vendors 
                         select ve;

            if (!String.IsNullOrEmpty(sstring))
            {
                vendor = vendor.Where(s => s.vaccines.Contains(sstring));
                
            }

            return View(vendor);
        }

        // GET: /Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: /Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,vendorID,vendorName,vendorPhone,vendorFax,vendorEmail,vendorWebsite,vendorAddress1,vendorAddress2,city,state,zip,vaccines")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: /Vendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: /Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,vendorID,vendorName,vendorPhone,vendorFax,vendorEmail,vendorWebsite,vendorAddress1,vendorAddress2,city,state,zip,vaccines")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: /Vendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: /Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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
        public void ExporttoExcel()
        {
            var grid = new GridView();
            VendorDBContext db = new VendorDBContext();

            grid.DataSource = from data in db.Vendors.ToList()
                              select new
                              {
                                  VendorName = data.vendorName,
                                  VendorPhone = data.vendorPhone,
                                  VendorFax = data.vendorFax,
                                  VendorEmail = data.vendorEmail,
                                  VendorWebsite = data.vendorWebsite,
                                  VendorAddress1 = data.vendorAddress1,
                                  VendorAddress2 = data.vendorAddress2,
                                  VendorCity = data.city,
                                  VendorState = data.state,
                                  VendorZip = data.zip,
                                  Vaccines = data.vaccines
                                
                              };

            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=ExportedVaccineList.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);

            grid.RenderControl(htmlTextWriter);

            Response.Write(sw.ToString());
            Response.End();


            //StringWriter sw = new StringWriter();

        }
    }
}
