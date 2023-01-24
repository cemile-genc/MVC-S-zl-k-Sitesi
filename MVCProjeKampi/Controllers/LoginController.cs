using EntityLayer.Concrete;
using DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;

namespace MVCProjeKampi.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
    {
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());
      
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var adminuserinfo = context.Admins.FirstOrDefault
                (x => x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword);
            if (adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminName,false);
                Session["AdminName"] = adminuserinfo.AdminName;

                return RedirectToAction("Index", "AdminCategory");

            }
            else
            {
				Response.Write("<script language='javascript'>alert(\"Hatalı Kullanıcı Adı veya Şifre Girdiniz\")</script>");
				return RedirectToAction("Index");
            }
        }
		[HttpGet]
		public ActionResult WriterLogin()
		{
			return View();
		}
        [HttpPost]
		public ActionResult WriterLogin(Writer writer)
		{
            //Context context = new Context();
            //var writeruserinfo = context.Writers.FirstOrDefault
            //	(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            var writeruserinfo = writerLoginManager.GetWriter(writer.WriterMail, writer.WriterPassword);
			if (writeruserinfo != null)
			{
				FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
				Session["WriterMail"] = writeruserinfo.WriterMail;

				return RedirectToAction("MyContent", "WriterPanelContent");

			}
			else
			{
				return RedirectToAction("WriterLogin");
			}
		}
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
      
	}
}