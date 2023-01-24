using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        //Category manager dan bir veri üret, bu veride EFCategoryDal den veri çekecek.
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles ="B")] //sadece b rolünde olan admin kategorilere erişebilir.
        public ActionResult Index()
        {
            var CategoryValues = categoryManager.GetList();
            return View(CategoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryvalidator = new CategoryValidator();  
            ValidationResult results = categoryvalidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAddBusinessLayer(category);
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id) 
        {
            var categoryvalue = categoryManager.GetById(id); //önce silinecek verinin id değerine ulaş
            categoryManager.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue=categoryManager.GetById(id); //önce güncellenecek verinin id değerine ulaş
            //categoryManager.CategoryUpdate(categoryvalue);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index");
        }

    }
}