using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFilesDal());

        public ActionResult Index()
        {
            var files = imageFileManager.GetList();
            return View(files);
        }
    }
}