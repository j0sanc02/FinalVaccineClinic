using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityofLouisvilleVaccine.Models;
using UniversityofLouisvilleVaccine.DataContexts;
using System.IO;

namespace UniversityofLouisvilleVaccine.Controllers
{
    public class GrantDocsController : Controller
    {
        private GrantDocsDBContext db = new GrantDocsDBContext();

        // GET: /GrantDocs/
        public ActionResult Index(string sortby)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortby) ? "Name desc" : "";
            ViewBag.DocTypeSort = sortby == "doc type" ? "doc type desc" : "doc type";
            ViewBag.FileNameSort = sortby == "fName" ? "fName desc" : "fName";
            ViewBag.UpDateSort = sortby == "up date" ? "up date desc" : "up date type";


            var grants = from a in db.GrantDoc select a;
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

            string[] dirs = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"Documents\", "*.*");
            ViewBag.filename = dirs.ToString();
            return View(db.GrantDoc.ToList());
        }

        // GET: /GrantDocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantDocs grantdocs = db.GrantDoc.Find(id);
            if (grantdocs == null)
            {
                return HttpNotFound();
            }
            return View(grantdocs);
        }

        // GET: /GrantDocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GrantDocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,fileName,docType,uploadDate")] GrantDocs grantdocs, HttpPostedFileBase upload)
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

                        var document = new DocFilePath
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Document
                        };

                        grantdocs.DocFilePaths = new List<DocFilePath>();
                        grantdocs.DocFilePaths.Add(document);
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Documents"), document.FileName));
                    }

                    db.GrantDoc.Add(grantdocs);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(grantdocs);
        }

        // GET: /GrantDocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantDocs grantdocs = db.GrantDoc.Find(id);
            if (grantdocs == null)
            {
                return HttpNotFound();
            }
            return View(grantdocs);
        }

        // POST: /GrantDocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,fileName,docType,uploadDate")] GrantDocs grantdocs, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload != null && upload.ContentLength > 0)
                    {
                        var document = new DocFilePath
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Document
                        };

                        grantdocs.DocFilePaths = new List<DocFilePath>();
                        grantdocs.DocFilePaths.Add(document);
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Documents"), document.FileName));
                    }

                }

                db.Entry(grantdocs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grantdocs);
        }

        // GET: /GrantDocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrantDocs grantdocs = db.GrantDoc.Find(id);
            if (grantdocs == null)
            {
                return HttpNotFound();
            }
            return View(grantdocs);
        }

        // POST: /GrantDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id,string document)
        {
            GrantDocs grantdocs = db.GrantDoc.Find(id);
            db.GrantDoc.Remove(grantdocs);
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
    }
}
