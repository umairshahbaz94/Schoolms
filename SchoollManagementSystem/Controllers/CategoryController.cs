using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult listingCategory()
        {
            Categoryservice Categoryservice = new Categoryservice();
            var listCategorys = Categoryservice.getCategory();
            return View(listCategorys);
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category Category)
        {
            Categoryservice service = new Categoryservice();
            service.saveCategory(Category);
            return View("AddCategory");
        }
        public ActionResult EditCategory(int id)
        {
            Categoryservice service = new Categoryservice();
            var Category = service.getbyid(id);
            return View(Category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category Category)
        {
            Categoryservice service = new Categoryservice();
            service.updateCategory(Category);
            return RedirectToAction("listingCategory");
        }
    }
}