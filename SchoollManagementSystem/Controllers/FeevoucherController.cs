using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SMS.Data;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class FeevoucherController : Controller
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
        Programdegreesservice programdegreesservice = new Programdegreesservice();
        FeeVoucherTypeservice FeeVoucherTypeservice = new FeeVoucherTypeservice();


       

        FeeScheduleStructureservice FeeScheduleStructureservice = new FeeScheduleStructureservice();
        SubHead3Codeservice SubHead3Codeservice = new SubHead3Codeservice();
        FeeVoucherHeadDetailservice FeeVoucherHeadDetailservice = new FeeVoucherHeadDetailservice(); 
        // GET: Feevoucher
        public ActionResult addheadvalue()
        {
            ViewBag.getclass = classservice.getclasses();
            ViewBag.subhead3 = SubHead3Codeservice.getSubHead3Code();
            ViewBag.feestructure =FeeScheduleStructureservice.getFeeScheduleStructure();

            return View();
        }
        [HttpPost]
        public ActionResult addheadvalue(FeeVoucherHeadDetail feeVoucherHeadDetail)
        {

            FeeVoucherHeadDetailservice.saveFeeVoucherHeadDetail(feeVoucherHeadDetail);
            return RedirectToAction("HeadsList");
        }
        public ActionResult HeadsList()
        {

            var get = from f in FeeVoucherHeadDetailservice.getFeeVoucherHeadDetail()
                      join s in SubHead3Codeservice.getSubHead3Code() on f.SubHead3Code equals s.SubHeadCode3
                      join fe in FeeScheduleStructureservice.getFeeScheduleStructure() on  f.fk_strif equals fe.FeeStrID
                      select new feeeheadvm
                      {
                          FeeScheduleStructure=fe,
                          FeeVoucherHeadDetail = f,
                          SubHead3Code = s,
                          


                      };
            return View(get);
        }
        public ActionResult updateheadvalue(int id)
        {

            ViewBag.subhead3 = SubHead3Codeservice.getSubHead3Code();
            ViewBag.feestructure = FeeScheduleStructureservice.getFeeScheduleStructure();
          var get=  FeeVoucherHeadDetailservice.getbyid(id);
            return View(get);
        }
        [HttpPost]
        public ActionResult updateheadvalue(FeeVoucherHeadDetail feeVoucherHeadDetail)
        {

            FeeVoucherHeadDetailservice.updateFeeVoucherHeadDetail(feeVoucherHeadDetail);
            return RedirectToAction("HeadsList");
        }

        public ActionResult FeeScheduleStructuresList()
        {
            var model = from c in FeeScheduleStructureservice.getFeeScheduleStructure()

                        join sec in sectionservice.getsection() on c.FVSectionCode equals sec.id
                        join Session in sessionservice.getsession() on c.FVSessionCode equals Session.ID
                        join classes in classservice.getclasses() on c.FVClassCode equals classes.ID
                        join C in categoryservice.getCategory() on c.FVCategoryCode equals C.id
                        join b in branchservice.getbranch() on c.FVBranchCode equals b.ID
                        join t in termservice.getTerm() on c.FVTermCode equals t.id
                        select new StudentDisplayVM
                        {
                            term=t,
                           section=sec,
                           session=Session,
                           Classes=classes,
                          Category=C,
                          FeeScheduleStructure=c,
                          Branch=b,
                           
                           

                        };


            return View(model);
        }

        public ActionResult addFeeStructures()
        {

            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass =classservice.getclasses().ToList();
            ViewBag.branchlist = branchservice.getbranch().ToList();
            ViewBag.catlist = categoryservice.getCategory().ToList();
            ViewBag.getprogram = programdegreesservice.getProgramdegree().ToList();
            ViewBag.vouchertype=FeeVoucherTypeservice.getFeeVoucherType().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult addFeeStructures(FeeScheduleStructure feeScheduleStructure)
        {
            FeeScheduleStructureservice.saveFeeScheduleStructure(feeScheduleStructure);
            return RedirectToAction("FeeScheduleStructuresList");
        }
        public ActionResult updateFeeStructures(int id)
        {

            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = classservice.getclasses().ToList();
            ViewBag.branchlist = branchservice.getbranch().ToList();
            ViewBag.catlist = categoryservice.getCategory().ToList();
            ViewBag.vouchertype = FeeVoucherTypeservice.getFeeVoucherType().ToList();
           var list= FeeScheduleStructureservice.getbyid(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult updateFeeStructures(FeeScheduleStructure feeScheduleStructure)
        {
            FeeScheduleStructureservice.updateFeeScheduleStructure(feeScheduleStructure);
            return RedirectToAction("FeeScheduleStructuresList");
        }
        public ActionResult findstudentstatus(StudentfeesStatusmodel st)
        {
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = classservice.getclasses().ToList();
            ViewBag.branchlist = branchservice.getbranch().ToList();
            ViewBag.catlist = categoryservice.getCategory().ToList();



            return View();

        }
        [HttpPost]
        public ActionResult findstudentstatus(FormCollection fc)
        {
            StudentCurrentStatus st = new StudentCurrentStatus();
            st.classesID = Convert.ToInt32((fc["cbosection"]));
            st.CategoryID= Convert.ToInt32((fc["cbocategory"]));
            st.SessionID = Convert.ToInt32((fc["cbosession"]));
            st.TermID = Convert.ToInt32((fc["cboterm"]));
            st.SectionID = Convert.ToInt32((fc["cbosection"]));
            return View("StudentFeesStatus", new { classid = st.Classes.ID, catid = st.Category.id, Sid = st.Category.id, tid = st.TermID,sec=st.SectionID });

        }

        [HttpGet]
        public ActionResult StudentFeesStatus(int ? cboclass, int ? cbosession, int ? cbocategory, int cboterm, int cbosection)
        {
                  SMSContext SMSContext = new SMSContext();
            ViewBag.classname = classservice.getclasses().Where(y=>y.ID==cboclass).Select(x => x.classname).SingleOrDefault();
            ViewBag.session =sessionservice.getsession().Where(y=>y.ID==cbosession).Select(x=>x.Sessionname).SingleOrDefault();
            ViewBag.cat = categoryservice.getCategory().Where(y => y.id == cbocategory).Select(x => x.CategoryName).SingleOrDefault();
            ViewBag.sems = termservice.getTerm().Where(y=>y.id==cboterm).Select(x=>x.TermName).SingleOrDefault();
            ViewBag.section =sectionservice.getsection().Where(y=>y.id==cbosection).Select(x=>x.sectionName).SingleOrDefault();

            SqlParameter classids  = new SqlParameter("@classid", cboclass);
            SqlParameter catids = new SqlParameter("@catid" , cbocategory);
            SqlParameter sids = new SqlParameter( "@Sid"  , cbosession);
            SqlParameter tids = new SqlParameter( "@tid", cboterm);
            SqlParameter secs = new SqlParameter("@sec", cbosection);
            ViewBag.name = "cboclass="+cboclass +  "&" + "cbosession=" + cbosession + "&" + "cbocategory=" + cbocategory + "&" + "cboterm=" + cboterm + "&" + "cbosection=" + cbosection;
            var list = SMSContext.Database.SqlQuery<StudentfeesStatusmodel>("studentfeesstatuss @classid,@catid,@Sid,@tid,@sec", classids,catids,sids,tids,secs).ToList();
            return View(list);

        }

        public ActionResult updatestatus(int id)
            
        {

            StudentFeesStatusservice studentFeesStatusservice = new StudentFeesStatusservice();
            statustblsservice statustblsservice = new statustblsservice();
            ViewBag.statuses = statustblsservice.getstatustbls().ToList();
            var getstudentfees = studentFeesStatusservice.getbyid(id);
            if (Request.IsAjaxRequest())
            {
                return PartialView(getstudentfees);
            }
            else { return PartialView(getstudentfees); }
        }
        [HttpPost]
        public ActionResult updatestatus(StudentFeesStatus studentFeesStatus)

        {

            var result = false;
            JsonResult obj = new JsonResult();
            if(studentFeesStatus.DueDate!=null && studentFeesStatus.DueDatev!=null)
            {
                studentFeesStatus.status = 2;
                studentFeesStatus.SStatus = 2;
            }
            if(studentFeesStatus.DueDate != null && studentFeesStatus.DueDatev == null)
            {
                studentFeesStatus.SStatus = 1;
                studentFeesStatus.status = 3;

            }
            if( studentFeesStatus.DueDate == null && studentFeesStatus.DueDatev != null )
            {
                studentFeesStatus.SStatus = 1;
                studentFeesStatus.status = 3;
            }
            StudentFeesStatusservice studentFeesStatusservice = new StudentFeesStatusservice();
            var ok = studentFeesStatusservice.updateStudentFeesStatus(studentFeesStatus);
            if (ok)
            {
                obj.Data = new { Success = true, Message = "Record Enter Sucessfully" };
            }
            else
            {

                obj.Data = new { error = false, Message = "not Enter" };
            }
            return obj;
        }

        public ActionResult findstudentstatusv(StudentfeesStatusmodel st)
        {
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = classservice.getclasses().ToList();
            ViewBag.branchlist = branchservice.getbranch().ToList();
            ViewBag.catlist = categoryservice.getCategory().ToList();



            return View();

        }
        [HttpPost]
        public ActionResult findstudentstatusv(FormCollection fc)
        {
            StudentCurrentStatus st = new StudentCurrentStatus();
            st.classesID = Convert.ToInt32((fc["cbosection"]));
            st.CategoryID = Convert.ToInt32((fc["cbocategory"]));
            st.SessionID = Convert.ToInt32((fc["cbosession"]));
            st.TermID = Convert.ToInt32((fc["cboterm"]));
            st.SectionID = Convert.ToInt32((fc["cbosection"]));
            ViewBag.name = "classid= " + st.classesID + "catid="+st.CategoryID ; 
            return View(" StudentFeesStatusv", new { classid = st.Classes.ID, catid = st.Category.id, Sid = st.Category.id, tid = st.TermID ,sec=st.SectionID});

        }
        public ActionResult StudentFeesStatusv(int? cboclass, int? cbosession, int? cbocategory, int cboterm,int cbosection)
        {
            SMSContext SMSContext = new SMSContext();
            SqlParameter classids = new SqlParameter("@classid", cboclass);
            SqlParameter catids = new SqlParameter("@catid", cbosession);
            SqlParameter sids = new SqlParameter("@Sid", cbocategory);
            SqlParameter tids = new SqlParameter("@tid", cboterm);
            SqlParameter secs = new SqlParameter("@sec", cbosection);

            ViewBag.name = "cboclass=" + cboclass + "&" + "cbosession=" + cbosession + "&" + "cbocategory=" + cbocategory + "&" + "cboterm=" + cboterm + "&" + "cbosection=" + cbosection;
            var list = SMSContext.Database.SqlQuery<StudentfeesStatusmodel>("studentfeesstatussshared @classid,@catid,@Sid,@tid,@sec", classids, catids, sids, tids, secs).ToList();
            return View(list);

        }
        public ActionResult updatestatusv(int id)

        {
            StudentFeesStatusservice studentFeesStatusservice = new StudentFeesStatusservice();
            statustblsservice statustblsservice = new statustblsservice();
            ViewBag.statuses = statustblsservice.getstatustbls().ToList();
            var getstudentfees = studentFeesStatusservice.getbyid(id);
            return View(getstudentfees);
        }
        [HttpPost]
        public ActionResult updatestatusv(StudentFeesStatus studentFeesStatus)

        {
            StudentFeesStatusservice studentFeesStatusservice = new StudentFeesStatusservice();
            studentFeesStatusservice.updateStudentFeesStatus(studentFeesStatus);

            return RedirectToAction("findstudentstatusv");
        }
    }
}
   