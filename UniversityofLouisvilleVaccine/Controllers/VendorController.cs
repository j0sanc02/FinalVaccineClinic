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
    [Authorize(Roles = "Admin, Executive, ProgramStaff")]
    public class VendorController : Controller
    {
        private VendorDBContext db = new VendorDBContext();

        // GET: /Vendor/
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Index(string sstring, string sortby)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortby) ? "Name desc" : "";
            ViewBag.vNameSort = sortby == "vName" ? "vName desc" : "vName";
            ViewBag.TelNumSort = sortby == "telnum" ? "telnum desc" : "telnum";
            ViewBag.FaxNumSort = sortby == "faxnum" ? "faxnum desc" : "faxnum";
            ViewBag.EmailSort = sortby == "email" ? "email desc" : "email";
            ViewBag.WebSiteSort = sortby == "website" ? "website desc" : "website";
            ViewBag.CitySort = sortby == "city" ? "city desc" : "city";
            ViewBag.StateSort = sortby == "state" ? "state desc" : "state";
            ViewBag.ZipSort = sortby == "zip" ? "zip desc" : "zip";
            ViewBag.VaccineSort = sortby == "vaccines" ? "vaccines desc" : "vaccines";



            var vendor = from ve in db.Vendors
                         select ve;
            switch (sortby)
            {
                case "Name desc":
                    vendor = vendor.OrderByDescending(s => s.vendorName);
                    break;
                case "Name":
                    vendor = vendor.OrderBy(s => s.vendorName);
                    break;
                case "vName":
                    vendor = vendor.OrderBy(s => s.vendorName);
                    break;
                case "vName desc":
                    vendor = vendor.OrderByDescending(s => s.vendorName);
                    break;
                case "telnum":
                    vendor = vendor.OrderBy(s => s.vendorPhone);
                    break;
                case "telnum desc":
                    vendor = vendor.OrderByDescending(s => s.vendorPhone);
                    break;
                case "faxnum":
                    vendor = vendor.OrderBy(s => s.vendorFax);
                    break;
                case "faxnum desc":
                    vendor = vendor.OrderByDescending(s => s.vendorFax);
                    break;
                case "email":
                    vendor = vendor.OrderBy(s => s.vendorEmail);
                    break;
                case "email desc":
                    vendor = vendor.OrderByDescending(s => s.vendorEmail);
                    break;
                case "website":
                    vendor = vendor.OrderBy(s => s.vendorWebsite);
                    break;
                case "website desc":
                    vendor = vendor.OrderByDescending(s => s.vendorWebsite);
                    break;
                case "city":
                    vendor = vendor.OrderBy(s => s.city);
                    break;
                case "city desc":
                    vendor = vendor.OrderByDescending(s => s.city);
                    break;
                case "state":
                    vendor = vendor.OrderBy(s => s.state);
                    break;
                case "state desc":
                    vendor = vendor.OrderByDescending(s => s.state);
                    break;
                case "zip":
                    vendor = vendor.OrderBy(s => s.zip);
                    break;
                case "zip desc":
                    vendor = vendor.OrderByDescending(s => s.zip);
                    break;
                case "vaccines":
                    vendor = vendor.OrderBy(s => s.vaccines);
                    break;
                case "vaccines desc":
                    vendor = vendor.OrderByDescending(s => s.vaccines);
                    break;


                default:
                    vendor = vendor.OrderBy(s => s.vendorName);
                    break;
            }
         

            if (!String.IsNullOrEmpty(sstring))
            {
                vendor = vendor.Where(s => s.vaccines.Contains(sstring));
                
            }

            return View(vendor);
        }

        // GET: /Vendor/Details/5
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
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
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
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
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
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
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
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
        [Authorize(Roles = "Admin, Executive")]
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
        [Authorize(Roles = "Admin, Executive")]
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

        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
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
