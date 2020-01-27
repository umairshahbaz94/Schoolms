using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Data;

namespace SchoollManagementSystem.Controllers
{
    public class RecordheadController : Controller
    {
        StudentCurrentStatuseservice StudentCurrentStatuseservice = new StudentCurrentStatuseservice();
        classesStudentMappingservice classesStudentMappingservice = new classesStudentMappingservice();
        Branchservice branchservice = new Branchservice();
        sectionservice sectionservice = new sectionservice();
        FeeVoucherType FeeVoucherType = new FeeVoucherType();
        Sessionservice sessionservice = new Sessionservice();
        Termservice termservice = new Termservice();
        Studentservice studentservice = new Studentservice();
        Categoryservice categoryservice = new Categoryservice();
        classservice classservice = new classservice();
        FeeVoucherTypeservice FeeVoucherTypeservice = new FeeVoucherTypeservice();
        Programdegreesservice programdegreesservice = new Programdegreesservice();
      
       SubHead3Codeservice subHead3Codeservice= new SubHead3Codeservice();

        // GET: Recordhead
        public ActionResult Index()
        {
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = classservice.getclasses().ToList();
            ViewBag.branchlist = branchservice.getbranch().ToList();
            ViewBag.catlist = categoryservice.getCategory().ToList();
            ViewBag.programall = programdegreesservice.getProgramdegree().ToList();
            ViewBag.head = subHead3Codeservice.getSubHead3Code().ToList();
            ViewBag.headv = FeeVoucherTypeservice.getFeeVoucherType().ToList();
            return View();
        }
        public ActionResult FindByHead(int? cboclass, int? cbosession,int? cbovoucher, int? cbocategory, int? cboterm, int? cbosection,
            int? cboprogram, int? cbohead,DateTime start,DateTime  End)
        {
            
            SMSContext SMSContext = new SMSContext();
            ViewBag.classname = classservice.getclasses().Where(y => y.ID == cboclass).Select(x => x.classname).SingleOrDefault();
            ViewBag.session = sessionservice.getsession().Where(y => y.ID == cbosession).Select(x => x.Sessionname).SingleOrDefault();
            ViewBag.cat = categoryservice.getCategory().Where(y => y.id == cbocategory).Select(x => x.CategoryName).SingleOrDefault();
            ViewBag.sems = termservice.getTerm().Where(y => y.id == cboterm).Select(x => x.TermName).SingleOrDefault();
            ViewBag.section = sectionservice.getsection().Where(y => y.id == cbosection).Select(x => x.sectionName).SingleOrDefault();
            ViewBag.startdata = start;
            ViewBag.enddata = End;
            

           
            SqlParameter starts = new SqlParameter("@start",start);
            SqlParameter ends = new SqlParameter("@end", End);
            SqlParameter classids = new SqlParameter("@classid", cboclass);
            SqlParameter type = new SqlParameter("@type", cbovoucher);
            SqlParameter sids = new SqlParameter("@seid", cbosession);
            SqlParameter tids = new SqlParameter("@smid", cboterm);
            SqlParameter secs = new SqlParameter("@secid", cbosection);
            SqlParameter pid = new SqlParameter("@pid ", cboprogram);
            SqlParameter hid = new SqlParameter("@hid",cbohead);
            SqlParameter cid = new SqlParameter("@cid", cbocategory);

            ViewBag.name = "cboclass=" + cboclass + "&" + "cbosession=" + cbosession + "&" + "cbovoucher=" + cbovoucher + "&" + "cbocategory=" + cbocategory + "&" + "cboterm=" + cboterm + "&" + "cbosection=" + cbosection  + "&"+ "cboprogram=" + cboprogram+"&"+"cbohead="+cbohead+"&"+"start="+start+"&"+"End="+End;
            var list = SMSContext.Database.SqlQuery<vocuherheadvm>("getresultbyhead @classid,@seid,@type,@smid,@secid,@pid,@hid,@cid,@start,@end", classids, sids, type,tids, secs, pid, hid,cid,starts,ends).ToList();

       
            return View(list);
        }


    }
}