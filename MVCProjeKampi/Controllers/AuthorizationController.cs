using BusinessLayer.Concrete;
using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
		RoleManager roleManager = new RoleManager(new EfRoleDal());
		// GET: Authorization
		public ActionResult Index()
        {
            var adminvalues = adminManager.GetList();
            return View(adminvalues);
        }
        
        [HttpGet]
        public ActionResult AddAdmin()
        {
			return View();
		}
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }
		[HttpGet]
		public ActionResult EditAdmin(int id)
		{
			var adminvalue = adminManager.GetById(id); //önce güncellenecek verinin id değerine ulaş
															 //categoryManager.CategoryUpdate(categoryvalue);
			return View(adminvalue);
		}
		[HttpPost]
		public ActionResult EditAdmin(Admin admin)
		{
			admin.AdminStatus = true;
			adminManager.AdminUpdate(admin);
			return RedirectToAction("Index");
		}
		public ActionResult DeleteAdmin(int id)
		{
			var result = adminManager.GetById(id);
			if (result.AdminStatus == true)
			{
				result.AdminStatus = false;
			}
			else
			{
				result.AdminStatus = true;
			}
			adminManager.AdminUpdate(result);
			return RedirectToAction("Index");
		}
	}
}