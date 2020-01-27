using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class TermController : Controller
    {
        // GET: Term
        public ActionResult listingTerm()
        {
            Termservice Termservice = new Termservice();
            var listTerms = Termservice.getTerm();
            return View(listTerms);
        }
        public ActionResult AddTerm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTerm(Term Term)
        {
            Termservice service = new Termservice();
            service.saveTerm(Term);
            return View();
        }
        public ActionResult EditTerm(int id)
        {
            Termservice service = new Termservice();
            var Term = service.getbyid(id);
            return View(Term);
        }
        [HttpPost]
        public ActionResult EditTerm(Term Term)
        {
            Termservice service = new Termservice();
            service.updateTerm(Term);
            return View("AddTerm");
        }
    }
}