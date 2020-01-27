using SMS.Data;
using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class fineHeadController : Controller
    {
        fineHeadservice fineHeadservice = new fineHeadservice();
        FeeVoucherTypeservice FeeVoucherTypeservice = new FeeVoucherTypeservice();
        SMSContext _context = new SMSContext();
        // GET: fineHead
        public ActionResult Index(int StudentID,int vid,int bid,int cid, int pid, int seid,int ctid,int secid,int trid)
        {
            var fkid = (from id in _context.feeScheduleStructures.ToList()

                        where (id.FeeVoucherTypeCode == vid && id.FVBranchCode == bid && id.FVClassCode == cid
                        && id.ProgramdegreeId==pid
                         && id.FVSessionCode == seid
                         && id.FVCategoryCode == ctid
                         && id.FVSectionCode == secid
                        && id.FVTermCode == trid

)
                        select id.FeeStrID).First();
            var list = from n in _context.FeeVoucherHeadDetails.Where(x => x.fk_strif == fkid && x.HeadValue==0).ToList()
                       join c in _context.subHead3Codes.ToList() on n.SubHead3Code equals c.SubHeadCode3 
                       select new discountvm
                       {
                           FeeVoucherHeadDetail = n,
                           SubHead3Code = c

                       };

            ViewBag.vouchertype = FeeVoucherTypeservice.getFeeVoucherType().ToList();
            ViewBag.stdid = StudentID;
            ViewBag.semid = trid;
            ViewBag.vid = vid;
            //var list = fineHeadservice.getfinehead().ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc, Discounttbl discounttbl)
        {
            Random r = new Random();
            int j = r.Next();


            SMSContext _context = new SMSContext();

            string[] ids = fc["discountAmount"].Split(',');
            string[] code = fc["HeadValue"].Split(',');
            {
                foreach (var tuple in ids.Zip(code, (x, y) => (ids: x, code: y)))

                {

                    discounttbl.discountAmount = Convert.ToDecimal(tuple.ids);

                    discounttbl.headcode = Convert.ToInt32(tuple.code);
                    discounttbl.vocid = Convert.ToInt32(fc["vtype"]);
                    discounttbl.statusfine = 1;
                    discounttbl.DisID =j;




                    _context.discounttbls.Add(discounttbl);
                    _context.SaveChanges();


                }
                var list = fineHeadservice.getfinehead().ToList();
                return RedirectToAction("Studentsclasslist", "Student");


            }
        }

        public ActionResult finestudent()
        {
            SMSContext obj = new SMSContext();
            var list = obj.Database.SqlQuery<finelist>("getfineliststudent").ToList();
            return View(list);
        }
    }
}