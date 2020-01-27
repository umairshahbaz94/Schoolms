using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class SessionController : Controller
    {

        public ActionResult listingsession()
        {
            Sessionservice sessionservice= new Sessionservice();
            var Listsession = sessionservice.getsession();
            return View(Listsession);
        }
        public ActionResult AddSession()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSession(Session Session)
        {
            Sessionservice Sessionservices = new Sessionservice();
            Sessionservices.saveSession(Session);
            return View();
        }
        public ActionResult EditSession(int id)
        {
            Sessionservice Sessionservices = new Sessionservice();
          var Session=Sessionservices.getbyid(id);
            return View(Session);
        }
        [HttpPost]
        public ActionResult EditSession(Session Session)

        {
            Sessionservice Sessionservices = new Sessionservice();
            Sessionservices.updateSession(Session);
            return View("AddSession");
        }

    }
}