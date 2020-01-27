using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class subHead1CodesController : Controller
    {
        SubHead3Codeservice SubHead3Codeservice = new SubHead3Codeservice();
        SubHead2Codeservice SubHead2Codeservice = new SubHead2Codeservice();
        MHeadCodeservice mHeadCodeservice = new MHeadCodeservice();
        SubHead1Codeservice subHead1Codeservice = new SubHead1Codeservice();
        // GET: subHead1Codes
        public ActionResult ListsubHead1Codes()
        {

            var list = from s in subHead1Codeservice.getSubHead1Code()
                       join h in mHeadCodeservice.getMHeadCode() on s.MainHeadCode equals h.MainHeadCode
                       select new headvm
                       {
                           subHead1Code = s,
                           MHeadCode = h,
                       };
                        return View(list);
        }
        public ActionResult addsubhead()
        {
            ViewBag.headname = mHeadCodeservice.getMHeadCode();
            return View();
        }
       [HttpPost]
        public ActionResult addsubhead(SubHead1Code subHead1Code)
        {

            subHead1Codeservice.saveSubHead1Code(subHead1Code);

            return RedirectToAction("ListsubHead1Codes");
        }

        public ActionResult updatesubhead(int id)
        {
            ViewBag.headname = mHeadCodeservice.getMHeadCode();
            var data=   subHead1Codeservice.getbyid(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult updatesubhead(SubHead1Code subHead1Code)
        {

            subHead1Codeservice.updateSubHead1Code(subHead1Code);

            return RedirectToAction("ListsubHead1Codes");
        }
        public ActionResult ListsubHead2list()
        {

            var list = from s in SubHead2Codeservice.getSubHead2Code()
                      
                       join h2 in subHead1Codeservice.getSubHead1Code() on s.SubHead1Code equals h2.SubHeadCode1
                       join h in mHeadCodeservice.getMHeadCode() on h2.MainHeadCode equals h.MainHeadCode
                       select new headvm
                       {
                           subHead1Code =h2 ,
                           MHeadCode = h,
                           subHead2Code =s,
                       };
            return View(list);
        }

        public ActionResult addsubhead2()
        {
            ViewBag.subhead1 = subHead1Codeservice.getSubHead1Code();

            ViewBag.headname = mHeadCodeservice.getMHeadCode();
            return View();
        }
        [HttpPost]
        public ActionResult addsubhead2(SubHead2Code subHead2Code)
        {

          SubHead2Codeservice.saveSubHead2Code(subHead2Code);

            return RedirectToAction("ListsubHead2list");
        }

        public ActionResult updatesubhead2(int id)
        {
            ViewBag.subhead1 = subHead1Codeservice.getSubHead1Code();

           
            ViewBag.headname = mHeadCodeservice.getMHeadCode();
            var data = SubHead2Codeservice.getbyid(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult updatesubhead2(SubHead2Code subHead2Code)
        {

            SubHead2Codeservice.updateSubHead2Code(subHead2Code);

            return RedirectToAction("ListsubHead2list");
        }

        public ActionResult ListsubHead3list()
        {

            var list = from s3 in SubHead3Codeservice.getSubHead3Code()


                          
                       join h3 in SubHead2Codeservice.getSubHead2Code() on s3.SubHead2Code equals h3.SubHeadCode2
                       join h2 in subHead1Codeservice.getSubHead1Code() on h3.SubHead1Code equals h2.SubHeadCode1
                       join h in mHeadCodeservice.getMHeadCode() on h2.MainHeadCode equals h.MainHeadCode


                       select new headvm
                       {
                           SubHead3Code=s3,
                           MHeadCode = h,
                          subHead1Code = h2,
                         
                           subHead2Code=h3
                          
                           
                       };
            return View(list);
        }
        public ActionResult updatesubhead3(int id)

        {
            ViewBag.subhead2 = SubHead2Codeservice.getSubHead2Code();

            ViewBag.subhead1 = subHead1Codeservice.getSubHead1Code();


            ViewBag.headname = mHeadCodeservice.getMHeadCode();
            var data = SubHead3Codeservice.getbyid(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult updatesubhead3(SubHead3Code subHead3Code)
        {

            SubHead3Codeservice.updateSubHead3Code(subHead3Code);

            return RedirectToAction("ListsubHead3list");
        }
        public ActionResult addsubhead3()
        {
            ViewBag.subhead1 = subHead1Codeservice.getSubHead1Code();
            ViewBag.subhead2 = SubHead2Codeservice.getSubHead2Code();

            ViewBag.headname = mHeadCodeservice.getMHeadCode();
            return View();
        }
        [HttpPost]
        public ActionResult addsubhead3(SubHead3Code subHead3Code)
        {

          
            SubHead3Codeservice.saveSubHead3Code(subHead3Code);

            return RedirectToAction("ListsubHead3list");
        }

    }

}