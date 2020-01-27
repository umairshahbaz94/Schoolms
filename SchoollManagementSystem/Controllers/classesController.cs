using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class classesController : Controller
    {

        public ActionResult listingClass()
        {
            classservice classservice = new classservice();
            var ListClass = classservice.getclasses();
            return View(ListClass);
        }
        public ActionResult Addclasses()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addclasses(classes classes)
        {
            classservice classesservice = new classservice();
            classesservice.saveclasses(classes);
            return View();
        }
        public ActionResult Editclasses(int id)
        {
            classservice classesservice = new classservice();
            var classes = classesservice.getbyid(id);
            return View(classes);
        }
        [HttpPost]
        public ActionResult Editclasses(classes classes)
        {
            classservice classesservice = new classservice();
            classesservice.updateclasses(classes);
            return View("Addclasses");
        }

    }
}