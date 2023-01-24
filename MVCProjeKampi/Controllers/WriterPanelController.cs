using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProjeKampi.Controllers
{
	public class WriterPanelController : Controller
	{
		HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
		WriterManager writerManager = new WriterManager(new EfWriterDal());
		WriterValidator writerValidator = new WriterValidator();

		Context context = new Context();
		// GET: WriterPanel
		[HttpGet]
		public ActionResult WriterProfile(int id=0)
		{
			string p = (string)Session["WriterMail"];
			
			id = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
			var writervalue = writerManager.GetById(id);

			return View(writervalue);
		}
		[HttpPost]
		public ActionResult WriterProfile(Writer writer)
		{
			ValidationResult results = writerValidator.Validate(writer);
			if (results.IsValid)
			{
				writerManager.WriterUpdate(writer);
				return RedirectToAction("AllHeading", "WriterPanel");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(writer);
		}
		public ActionResult MyHeading(string p)
		{
			p = (string)Session["WriterMail"];
			var writeridinfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
			var values = headingManager.GetListByWriter(writeridinfo);
			return View(values);
		}
		[HttpGet]
		public ActionResult NewHeading()
		{
			//dropdown 
			List<SelectListItem> valuecategory = (from x in headingManager.GetList()
												  select new SelectListItem
												  {
													  Text = x.Category.CategoryName,
													  Value = x.CategoryId.ToString()
												  }).ToList();
			ViewBag.vlc = valuecategory;

			return View();
		}
		[HttpPost]
		public ActionResult NewHeading(Heading heading)
		{
			string writermailinfo = (string)Session["WriterMail"];
			var writeridinfo = context.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
			heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			heading.WriterId = writeridinfo;
			heading.HeadingStatus = true;
			headingManager.HeadingAdd(heading);
			return RedirectToAction("MyHeading");
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
			return RedirectToAction("MyHeading");
		}
		public ActionResult DeleteHeading(int id)
		{
			var headingvalue = headingManager.GetById(id);
			headingvalue.HeadingStatus = headingvalue.HeadingStatus == true ? false : true;

			headingManager.HeadingDelete(headingvalue);
			return RedirectToAction("MyHeading");
		}
		public ActionResult AllHeading(int page = 1)
		{
			var headings = headingManager.GetList().ToPagedList(page, 4);
			return View(headings);

		}
	}
}
// <customErrors mode="On">
// < error statusCode = "404" redirect = "/ErrorPage/Page404" />
//  </ customErrors >