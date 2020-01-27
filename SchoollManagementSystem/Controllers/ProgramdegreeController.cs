using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{

    public class ProgramdegreeController : Controller
    {
        // GET: Programdegree
        Programdegreesservice programdegreesservice = new Programdegreesservice();
        public ActionResult Index()
        {
         var list  = programdegreesservice.getProgramdegree();

            return View(list);
        }
        public ActionResult AddProgram()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddProgram(Programdegree programdegree)

        {
            programdegree.ProgramAddDate = DateTime.Now;

            programdegreesservice.saveProgramdegree(programdegree);
            return View();

        }
        [HttpGet]
        public ActionResult Updateprogram(int id)
        {

          var list=  programdegreesservice.getbyid(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult Updateprogram(Programdegree programdegree)
        {
            programdegreesservice.updateProgramdegree(programdegree);

            return View();
        }
    }
    }