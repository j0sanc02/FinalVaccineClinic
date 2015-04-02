using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace UniversityofLouisvilleVaccine.Controllers
{
    public class Grant2Controller : Controller
    {
        public ActionResult Index()
        {
            string[] dirs = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"FileUploads\", "*.*");
            return View(dirs.ToList());
        }

        [HttpPost]

        public ActionResult UploadToAppServer()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase hpf = Request.Files[i];
                if (hpf.ContentLength == 0)
                    continue;

                string savedFileName = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory + "FileUploads/",
                Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);
            }
            return RedirectToAction("Index");
        }

        public FileStreamResult StreamFileFromAppServer(string fileNameWithExtention)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "FileUploads/";
            string fileName = fileNameWithExtention;
            return File(new FileStream(path + fileName, FileMode.Open), "text/plain", fileName);
        }

        public FilePathResult DownloadFileFromAppServer(string fileNameWithExtention)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "FileUploads/";
            string fileName = fileNameWithExtention;
            return File(path + fileName, "text/plain", "test.txt");
            
        }

	}
}