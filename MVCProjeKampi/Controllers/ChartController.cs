﻿using EntityLayer.Concrete;
using MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json (BlogList(),JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses=new List<CategoryClass>();
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 8
            }); 
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 4
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 5
            });
            return categoryClasses;

        }
    }
}