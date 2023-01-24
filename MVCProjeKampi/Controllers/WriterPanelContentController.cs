using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
		ContentManager contentManager = new ContentManager(new EfContentDal());
		Context context = new Context();


		// GET: WriterPanelContent
		public ActionResult MyContent(string p)
        {
			//int id = 2;
			p = (string)Session["WriterMail"];
			//Sisteme hangi writerid ile authentice olunursa o id'yi çeker.
			var writeridInfo = context.Writers.Where(x => x.WriterMail==p).Select(y=>y.WriterId).FirstOrDefault();
			//ViewBag.d=p; ->Veritaşıma
			var contentvalues = contentManager.GetListByWriter(writeridInfo);
			return View(contentvalues);
		}
		[HttpGet]
		public ActionResult AddContent(int id)
		{
			ViewBag.d=id;
			return View();
		}
		[HttpPost]
		public ActionResult AddContent(Content content)
		{
			string mail = (string)Session["WriterMail"];
			var writeridInfo = context.Writers.Where(x => x.WriterMail==mail).Select(y=>y.WriterId).FirstOrDefault();
			content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			content.WriterId = writeridInfo;
			content.ContentStatus = true;
			contentManager.ContentAdd(content);
			return RedirectToAction("MyContent");
		}
		public ActionResult ToDoList()
		{
			return View();
		}
    }
}