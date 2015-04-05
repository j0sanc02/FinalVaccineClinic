﻿using Postal;
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
    
    public class VaccineUseController : Controller
    {
        private VaccineUseDBContext db = new VaccineUseDBContext();

        // GET: /VaccineUse/
        //[Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
        public ActionResult Index(string sortby)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortby) ? "Name desc" : "";
            ViewBag.DescSort = sortby == "vacID" ? "vacID desc" : "vacID";
            ViewBag.LotNumSort = sortby == "lot num" ? "lot num desc" : "lot num";
            ViewBag.ExpDateSort = sortby == "exp date" ? "exp date desc" : "exp date";
            ViewBag.PatIDSort = sortby == "patID" ? "patID desc" : "patID";
            ViewBag.LeftArmSort = sortby == "lArm" ? "lArm desc" : "lArm";
            ViewBag.RightArmSort = sortby == "rArm" ? "rArm desc" : "rARm";
            ViewBag.QuantRemSort = sortby == "quant rem" ? "quant rem desc" : "quant rem";
            ViewBag.UseDateSort = sortby == "use date" ? "use date desc" : "use date";


            var vaccines = from v in db.VaccineUses select v;
            switch (sortby)
            {
                case "Name desc":
                    vaccines = vaccines.OrderByDescending(s => s.vaccineID);
                    break;
                case "Name":
                    vaccines = vaccines.OrderBy(s => s.vaccineID);
                    break;
                case "vacID desc":
                    vaccines = vaccines.OrderByDescending(s => s.vaccineID);
                    break;
                case "vacID":
                    vaccines = vaccines.OrderBy(s => s.vaccineID);
                    break;
                case "lot num":
                    vaccines = vaccines.OrderBy(s => s.lotNumber);
                    break;
                case "lot num desc":
                    vaccines = vaccines.OrderByDescending(s => s.lotNumber);
                    break;
                case "exp date":
                    vaccines = vaccines.OrderBy(s => s.expdate);
                    break;
                case "exp date desc":
                    vaccines = vaccines.OrderByDescending(s => s.expdate);
                    break;
                case "patID":
                    vaccines = vaccines.OrderBy(s => s.patientID);
                    break;
                case "patID desc":
                    vaccines = vaccines.OrderByDescending(s => s.patientID);
                    break;
                case "lArm":
                    vaccines = vaccines.OrderBy(s => s.LinjectionSite);
                    break;
                case "lArm desc":
                    vaccines = vaccines.OrderByDescending(s => s.LinjectionSite);
                    break;
                case "rArm":
                    vaccines = vaccines.OrderBy(s => s.RinjectionSite);
                    break;
                case "rArm desc":
                    vaccines = vaccines.OrderByDescending(s => s.RinjectionSite);
                    break;
                case "quant rem":
                    vaccines = vaccines.OrderBy(s => s.quantity);
                    break;
                case "quant rem desc":
                    vaccines = vaccines.OrderByDescending(s => s.quantity);
                    break;
                case "use date":
                    vaccines = vaccines.OrderBy(s => s.VaccineUseDate);
                    break;
                case "use date desc":
                    vaccines = vaccines.OrderByDescending(s => s.VaccineUseDate);
                    break;

                default:
                    vaccines = vaccines.OrderBy(s => s.vaccineID);
                    break;
            }


            return View(vaccines);
        }

        // GET: /VaccineUse/Details/5
        //[Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineUse vaccineuse = db.VaccineUses.Find(id);
            if (vaccineuse == null)
            {
                return HttpNotFound();
            }
            return View(vaccineuse);
        }

        // GET: /VaccineUse/Create
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VaccineUse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Create([Bind(Include = "VaccineUseId,vaccineID,lotNumber,expdate,patientID,LinjectionSite,RinjectionSite,LIntradermal,RIntradermal,LIntramuscular,RIntramuscular,lsub,rsub,lnasal,rnasal,quantity,VaccineUseDate,emaildate")] VaccineUse vaccineuse)
        {

            if (ModelState.IsValid)
            {
                db.VaccineUses.Add(vaccineuse);
                db.SaveChanges();

                    //Decrease amount from quantity
                    VaccineDBContext VaccineDB = new VaccineDBContext();
                    Vaccine Vac = new Vaccine();

                    string vaccineID = vaccineuse.vaccineID;
                    string lot = vaccineuse.lotNumber;
                    int decreaseby = vaccineuse.quantity;
                    
                    var query =
                        from VDB in VaccineDB.Vaccines
                        where VDB.lotNumber == lot && VDB.vaccineID == vaccineID
                        select VDB;

                    foreach (Vaccine vdb in query)
                    {
                        int currentvaccinequantity = vdb.numofDoses;
                        int newvaccinetotal = currentvaccinequantity - decreaseby;                    
                        vdb.numofDoses = newvaccinetotal;
                    }

                    try
                    {
                        VaccineDB.SaveChanges();
                        VaccineDBContext vb3 = new VaccineDBContext();

                        var dosesum =
                            (from vb in vb3.Vaccines
                             where vb.vaccineID == vaccineID
                             select vb.numofDoses).Sum();

                        var avgwarning =
                            (from VDB in vb3.Vaccines
                             where VDB.vaccineID == vaccineID
                             select VDB.inventoryWarning).Average();

                        //var date =
                        //    from vdb in db.VaccineUses
                        //    where vdb.vaccineID == vaccineID
                        //    select vdb.emaildate;

                        if (avgwarning >= dosesum)
                        //Convert.ToInt32(date) >= Convert.ToInt32(DateTime.Today) + 7
                        //if (newvaccinetotal <= vdb.inventoryWarning)
                        {
                            dynamic email = new Email("Warning");
                            email.To = "j0sanc02@gmail.com";
                            email.Send();

                            //var q2 =
                            //    from vd2 in vb3.Vaccines
                            //    where vd2.vaccineID == vaccineID & vd2.lotNumber == lot
                            //    select vd2.vaccineName;

                            
                            //string vid = vaccineID;
                            //string name = q2.ToString();
                            //string lot2 = lot;
                            //DateTime sent = DateTime.Today;

                            //EmailLookupDBContext eldb = new EmailLookupDBContext();

                            //eldb.emaillookups.Create(vid, name, lot, sent );

                            //eldb.emaillookups.Add(vid, name, lot, sent);

                           
                            //foreach (Vaccine vdb in query2)
                            //{       
                            //int currentvaccinequantity = vdb.numofDoses;
                            //int newvaccinetotal = currentvaccinequantity - decreaseby;                    
                            //vdb.numofDoses = newvaccinetotal;
                            //}
                            
                            //ElookupDBContext edb = new ElookupDBContext();
                            //VaccineUse vu = new VaccineUse();
                            

                            
                            //string vid = v
                            //string lnum = Vac.lotNumber;
                            //DateTime exp = Vac.expDate;
                            //string patid = 
                            
                            
                            //edb.Elookups.Add(vid,lnum,exp);

                            //    try
                            //    {
                            //        var q2 =
                            //            from x in db.VaccineUses
                            //            where x.Equals(vaccineID)
                            //            select x;

                            //        foreach (VaccineUse c in q2)
                            //        {
                            //            c.emaildate = DateTime.Today;
                            //        }

                            //    }
                            //    catch (Exception e)
                            //    {
                            //        Console.WriteLine(e);
                            //    }

                            //}

                            //else if (avgwarning >= dosesum && Convert.ToInt32(date)>=Convert.ToInt32(DateTime.Today)+ Convert.ToInt32(DateTime.Now.AddDays(7)))
                            //{
                            //    dynamic email = new Email("Warning");
                            //    email.To = "j0sanc02@gmail.com";
                            //    email.Send();

                            //    try
                            //    {
                            //        var q2 =
                            //            from x in db.VaccineUses
                            //            where x.Equals(vaccineID)
                            //            select x;

                            //        foreach (VaccineUse c in q2)
                            //        {
                            //            c.emaildate = DateTime.Today;
                            //        }

                            //    }
                            //    catch (Exception e)
                            //    {
                            //        Console.WriteLine(e);
                            //    }
                            //}
                        }
                                            
                        Console.WriteLine("Vaccine Amount Updated!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
 
                return RedirectToAction("Index");
            }

            return View(vaccineuse);

        }

        // GET: /VaccineUse/Edit/5
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineUse vaccineuse = db.VaccineUses.Find(id);
            if (vaccineuse == null)
            {
                return HttpNotFound();
            }
            return View(vaccineuse);
        }

        // POST: /VaccineUse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Edit([Bind(Include = "VaccineUseId,vaccineID,lotNumber,expdate,patientID,LinjectionSite,RinjectionSite,LIntradermal,RIntradermal,LIntramuscular,RIntramuscular,lsub,rsub,lnasal,rnasal,quantity,VaccineUseDate,emaildate")] VaccineUse vaccineuse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccineuse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccineuse);
        }

        

        // GET: /VaccineUse/Delete/5
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineUse vaccineuse = db.VaccineUses.Find(id);
            if (vaccineuse == null)
            {
                return HttpNotFound();
            }
            return View(vaccineuse);
        }

        // POST: /VaccineUse/Delete/5
        //[Authorize(Roles = "Admin, Executive, ProgramStaff")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccineUse vaccineuse = db.VaccineUses.Find(id);
            db.VaccineUses.Remove(vaccineuse);
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
