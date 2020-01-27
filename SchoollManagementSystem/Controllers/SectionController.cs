using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class SectionController : Controller
    {
        // GET: Section
        // GET: Section
        public ActionResult listingsection()
        {
            sectionservice sectionservice = new sectionservice();
          var listsections=sectionservice.getsection();
            return View(listsections);
        }
        public ActionResult AddSection()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSection(Section section)
        {
            sectionservice service = new sectionservice();
            service.savesection(section);
            return View();
        }
        public ActionResult EditSection(int id)
        {
            sectionservice service = new sectionservice();
            var section = service.getbyid(id);
            return View(section);
        }
        [HttpPost]
        public ActionResult EditSection(Section section)
        {
            sectionservice service = new sectionservice();
            service.updatesection(section);
            return View("AddSection");
        }
    }
}