using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string contentId)
        {
            var values = contentManager.GetList(contentId);
         
            //var values = context.Contents.ToList();
            return View(values);

        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = contentManager.GetListByHeadingId(id);
            return View(contentvalues);
        }
    }
}