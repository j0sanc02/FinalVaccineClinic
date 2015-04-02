using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityofLouisvilleVaccine.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(file.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/FileUploads"), fileName);
                    file.SaveAs(path);
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Index");
            }
        }
	}
}