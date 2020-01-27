using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult listiBranch()
        {
            Branchservice branchservice = new Branchservice();
            var listbranch = branchservice.getbranch();
            return View(listbranch);
        }
        public ActionResult Addbranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addbranch(Branch branch)
        {
            Branchservice branchservice = new Branchservice();
            branchservice.savebranch(branch);
            return View();
        }
        public ActionResult Editbranch(int id)
        {
            Branchservice branchservice = new Branchservice();
          var branch=branchservice.getbyid(id);
            return View(branch);
        }
        [HttpPost]
        public ActionResult Editbranch(Branch branch)
        {
            Branchservice branchservice = new Branchservice();
            branchservice.updatebranch(branch);
            return View("Addbranch");
        }
    }
}