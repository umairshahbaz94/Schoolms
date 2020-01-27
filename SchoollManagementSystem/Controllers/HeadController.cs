using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class HeadController : Controller
    {
        // GET: Head

        public ActionResult Mheadlist()

        { 
            MHeadCodeservice mHeadCodeservice = new MHeadCodeservice();
          var list = mHeadCodeservice.getMHeadCode().ToList();
            return View(list);
        }
        public ActionResult addhead()

        {

            return View();
        }
        [HttpPost]
        public ActionResult addhead(MHeadCode mHeadCode)

        {
            MHeadCodeservice mHeadCodeservice = new MHeadCodeservice();
            mHeadCodeservice.saveMHeadCode(mHeadCode);

            return View("Mheadlist");
        }
        public ActionResult updatehead(int id)

        {
            MHeadCodeservice mHeadCodeservice = new MHeadCodeservice();
           var data= mHeadCodeservice.getbyid(id);


            return View(data);
        }
        [HttpPost]
        public ActionResult updatehead(MHeadCode mHeadCode)

        {
            MHeadCodeservice mHeadCodeservice = new MHeadCodeservice();
            mHeadCodeservice.updateMHeadCode(mHeadCode);
            return RedirectToAction("Mheadlist");
        }





    }

}