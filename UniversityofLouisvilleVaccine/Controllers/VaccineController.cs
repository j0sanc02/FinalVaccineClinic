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
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace UniversityofLouisvilleVaccine.Controllers
{
    [Authorize(Roles = "Admin, Executive, ProgramStaff, Research")]
    public class VaccineController : Controller
    {
        private VaccineDBContext db = new VaccineDBContext();

        // GET: /Vaccine/
        [Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
        public ActionResult Index(string lotnumber, string searchString, string StringID, string sortby)
        {

            ViewBag.NameSort = String.IsNullOrEmpty(sortby) ? "Name desc" : "";
            ViewBag.DescSort = sortby == "vacID" ? "vacID desc" : "vacID";
            ViewBag.DateSort = sortby == "recDate" ? "rec_date_desc" : "recDate";
            ViewBag.LeadTimeSort = sortby == "lead time" ? "lead time desc" : "lead time";
            ViewBag.LotNumSort = sortby == "lot num" ? "lot num desc" : "lot num";
            ViewBag.QuantRemSort = sortby == "quant rem" ? "quant rem desc" : "quant rem";
            ViewBag.CostSort = sortby == "cost" ? "cost desc" : "cost";
            ViewBag.ExpDateSort = sortby == "exp date" ? "exp date desc" : "exp date";


            var vaccines = from v in db.Vaccines select v;
            switch (sortby)
            {
                case "Name desc":
                    vaccines = vaccines.OrderByDescending(s => s.vaccineName);
                    break;
                case "Name":
                    vaccines = vaccines.OrderBy(s => s.vaccineName);
                    break;
                case "vacID desc":
                    vaccines = vaccines.OrderByDescending(s => s.vaccineID);
                    break;
                case "vacID":
                    vaccines = vaccines.OrderBy(s => s.vaccineID);
                    break;
                case "recDate":
                    vaccines = vaccines.OrderBy(s => s.dateReceived);
                    break;
                case "rec_date_desc":
                    vaccines = vaccines.OrderByDescending(s => s.dateReceived);
                    break;
                case "lead time":
                    vaccines = vaccines.OrderBy(s => s.leadTime);
                    break;
                case "lead time desc":
                    vaccines = vaccines.OrderByDescending(s => s.leadTime);
                    break;
                case "lot num":
                    vaccines = vaccines.OrderBy(s => s.lotNumber);
                    break;
                case "lot num desc":
                    vaccines = vaccines.OrderByDescending(s => s.lotNumber);
                    break;
                case "quant rem":
                    vaccines = vaccines.OrderBy(s => s.numofDoses);
                    break;
                case "quant rem desc":
                    vaccines = vaccines.OrderByDescending(s => s.numofDoses);
                    break;
                case "cost":
                    vaccines = vaccines.OrderBy(s => s.salesPrice);
                    break;
                case "cost desc":
                    vaccines = vaccines.OrderByDescending(s => s.salesPrice);
                    break;
                case "exp date":
                    vaccines = vaccines.OrderBy(s => s.expDate);
                    break;
                case "exp date desc":
                    vaccines = vaccines.OrderByDescending(s => s.expDate);
                    break;
                default:
                    vaccines = vaccines.OrderBy(s => s.vaccineName);
                    break;

            }
            
            var lotlist = new List<string>();

            var lotqry = from d in db.Vaccines
                         orderby d.lotNumber
                         select d.lotNumber;


            lotlist.AddRange(lotqry.Distinct());
            ViewBag.lotNumber = new SelectList(lotlist);

            //var vaccines = from v in db.Vaccines select v;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                vaccines = vaccines.Where(s => s.vaccineName.Contains(searchString));
                //vaccines = vaccines.Where(s => s.lotNumber.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(lotnumber))
            {
                vaccines = vaccines.Where(x => x.lotNumber == lotnumber);
            }
            
            
            return View(vaccines);
        }

        // GET: /Vaccine/Details/5
        [Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // GET: /Vaccine/Create
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vaccine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Create([Bind(Include = "ID,vaccineID,vaccineName,dateReceived,CPT,ICD9Code,NDC,leadTime,lotNumber,numofDoses,salesPrice,expDate,refugeePrice,clinicPrice,description,inventoryWarning")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Vaccines.Add(vaccine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaccine);
        }

        // GET: /Vaccine/Edit/5
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: /Vaccine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Edit([Bind(Include = "ID,vaccineID,vaccineName,dateReceived,CPT,ICD9Code,NDC,leadTime,lotNumber,numofDoses,salesPrice,expDate,refugeePrice,clinicPrice,description,inventoryWarning")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccine);
        }

        // GET: /Vaccine/Delete/5
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: /Vaccine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaccine vaccine = db.Vaccines.Find(id);
            db.Vaccines.Remove(vaccine);
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

        [Authorize(Roles = "Admin, Executive, ProgramStaff, Research")]
        public void ExporttoExcel()
        {
            var grid = new GridView();
            VaccineDBContext db = new VaccineDBContext();

            grid.DataSource = from data in db.Vaccines.ToList()
                              select new
                              {
                                  VaccineID = data.vaccineID,
                                  VaccineName = data.vaccineName,
                                  LotNumber = data.lotNumber,
                                  Expiration = data.expDate,
                                  DateReceived = data.dateReceived,
                                  CPT = data.CPT,
                                  ICD9Code = data.ICD9Code,
                                  NDC = data.NDC,
                                  LeadTime = data.leadTime,
                                  Quantity = data.numofDoses,
                                  Description = data.description,
                                  WarningAmount = data.inventoryWarning,
                                  RefugeePrice = data.refugeePrice,
                                  ClinicPrice = data.clinicPrice,
                                  Cost = data.salesPrice
                                  
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
