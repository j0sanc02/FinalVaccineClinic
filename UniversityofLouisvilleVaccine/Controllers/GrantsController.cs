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
    public class GrantsController : Controller
    {
        private GrantsDBContext db = new GrantsDBContext();

        // GET: /Grants/
        public ActionResult Index()
        {

            string[] dirs = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"Documents\", "*.*");
            ViewBag.filename = dirs.ToString();
            return View(db.Grant.ToList());
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
        public ActionResult Create([Bind(Include = "id,docType,fileName,uploadDate")]Grants grants, HttpPostedFileBase upload)
        {
                                            
            if (ModelState.IsValid)
            {
                //var filename = Path.GetFileName(grants.fileType.FileName);
                //string documentpath = "~/FileUploads/" + filename;
                //var path = Path.Combine(Server.MapPath("~/FileUploads/"), filename);
                //grants.fileType.SaveAs(path);  

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

                    db.Grant.Add(grants);
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
        public ActionResult Edit([Bind(Include = "id,docType,fileName,uploadDate")] Grants grants, HttpPostedFileBase upload)
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
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grants grants = db.Grant.Find(id);
            db.Grant.Remove(grants);
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

        public FilePathResult Download(string document)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Documents/";
            string fileName = document;
            return File(path + fileName, "text/plain", "test.txt");

        }

        //public FileResult Download(string document)
        //{
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(Path.Combine(Server.MapPath("~/Documents"), document));
        //    string fileName = "myfile.ext";
        //    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //}



    }
}
