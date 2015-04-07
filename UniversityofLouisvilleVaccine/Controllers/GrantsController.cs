using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityofLouisvilleVaccine.Models;
using UniversityofLouisvilleVaccine.DataContexts;
using System.IO;
using System;


namespace UniversityofLouisvilleVaccine.Controllers
{
    [Authorize(Roles = "Admin, Executive, Research, ProgramStaff")]
    public class GrantsController : Controller
    {
        private GrantsDBContext db = new GrantsDBContext();

        // GET: /Grants/
        public ActionResult Index(string sortby)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortby) ? "Name desc" : "";
            ViewBag.DocTypeSort = sortby == "doc type" ? "doc type desc" : "doc type";
            ViewBag.FileNameSort = sortby == "fName" ? "fName desc" : "fName";
            ViewBag.UpDateSort = sortby == "up date" ? "up date desc" : "up date type";


            var grants = from a in db.Grant select a;
            switch (sortby)
            {
                case "Name desc":
                    grants = grants.OrderByDescending(s => s.fileName);
                    break;
                case "Name":
                    grants = grants.OrderBy(s => s.fileName);
                    break;
                case "fName desc":
                    grants = grants.OrderByDescending(s => s.fileName);
                    break;
                case "fName":
                    grants = grants.OrderBy(s => s.fileName);
                    break;
                case "doc type":
                    grants = grants.OrderBy(s => s.docType);
                    break;
                case "doc type desc":
                    grants = grants.OrderByDescending(s => s.docType);
                    break;
                case "up date":
                    grants = grants.OrderBy(s => s.uploadDate);
                    break;
                case "up date desc":
                    grants = grants.OrderByDescending(s => s.uploadDate);
                    break;
                default:
                    grants = grants.OrderBy(s => s.fileName);
                    break;
            }

            return View(grants);

            //string[] dirs = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"Documents\", "*.*");
            //ViewBag.filename = dirs.ToString();
            //return View(db.Grant.ToList());
        }

        // GET: /Grants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grants grants = db.Grant.Find(id);

            if (grants == null)
            {
                return HttpNotFound();
            }
            return View(grants);
        }

        // GET: /Grants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Grants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,docType,filetitle,fileName,uploadDate")]Grants grants, HttpPostedFileBase upload)
        {
                                            
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {
                        var document = new FilePath
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Document
                        };

                        grants.FilePaths = new List<FilePath>();
                        grants.FilePaths.Add(document);
                        upload.SaveAs(Path.Combine(Server.MapPath("~/GrantDocuments"), document.FileName));

               

                        db.Grant.Add(grants);
                        db.SaveChanges();

                        var x = new FilePath
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Document
                        };
                        

                        string fn = x.FileName;

                        var query =
                            from f in db.Grant
                            where f.id == grants.id
                            select f;

                        foreach (Grants g in query)
                        {
                            g.fileName = fn;
                        }

                        db.SaveChanges();
                        return RedirectToAction("Index");
             
                }
            }

            return View(grants);
        }

        // GET: /Grants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grants grants = db.Grant.Find(id);
            if (grants == null)
            {
                return HttpNotFound();
            }
            return View(grants);
        }

        // POST: /Grants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,docType,filetitle,fileName,uploadDate")] Grants grants, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload != null && upload.ContentLength > 0)
                    {
                        var document = new FilePath
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Document
                        };

                        grants.FilePaths = new List<FilePath>();
                        grants.FilePaths.Add(document);
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Documents"), document.FileName));
                    }
                    
                }

                db.Entry(grants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grants);
        }

        // GET: /Grants/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grants grants = db.Grant.Find(id);
            if (grants == null)
            {
                return HttpNotFound();
            }
            return View(grants);
        }

        // POST: /Grants/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string document)
        {
            Grants grants = db.Grant.Find(id);
            db.Grant.Remove(grants);
            db.SaveChanges();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Documents/";
            if (System.IO.File.Exists(path + document))
            {

                System.IO.File.Delete(path + document);
            }
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

        public FilePathResult Download(string document)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Documents/";
            string fileName = document;
            return File(path + fileName, "text/plain", document);

        }

        //public FileResult Download(string document)
        //{
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath("~/Documents"), document));
        //    string fileName = "myfile.ext";
        //    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //}



    }
}
