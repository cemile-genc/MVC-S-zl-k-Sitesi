using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager( new EfHeadingDal());
		ContentManager contentManager = new ContentManager(new EfContentDal());

		// GET: Default
		public ActionResult Headings()
        {
            var headingList = headingManager.GetList();

            return View(headingList);
        }    
        public PartialViewResult Index(int id=0) //tıklanan başlığa göre id'aini alıp içerik listeleme
        {
            var contentList = contentManager.GetListByHeadingId(id);
            return PartialView(contentList);
        }
    }
}