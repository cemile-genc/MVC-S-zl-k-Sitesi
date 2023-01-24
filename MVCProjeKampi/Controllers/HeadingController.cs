using DataAccsessLayer.EntityFramework;
using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MVCProjeKampi.Controllers
{

    public class HeadingController : Controller
    {
        HeadingValidator headingValidator = new HeadingValidator();
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        // GET: Heading
        public ActionResult Index()
        {
            var HeadingValues = headingManager.GetList();

            return View(HeadingValues);

        }
        public ActionResult HeadingReport()
        {
			var HeadingValues = headingManager.GetList();

			return View(HeadingValues);
		}
        [HttpGet]
        public ActionResult AddHeading()
        {
            //dropdown 
            List<SelectListItem> valuecategory = (from x in headingManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Category.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> valuewriter = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + "" + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");

        }
      
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in headingManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Category.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> valuewriter = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + "" + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            var headingvalue = headingManager.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = headingManager.GetById(id);
            headingvalue.HeadingStatus = headingvalue.HeadingStatus == true ? false : true;
          
            headingManager.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }

    }
}
