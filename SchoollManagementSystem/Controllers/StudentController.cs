using SMS.Data;
using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SchoollManagementSystem.Controllers
{

    public class StudentController : Controller

    {
        setVoucherpercentservice setVoucherpercentservice = new setVoucherpercentservice();
        StudentCurrentStatuseservice StudentCurrentStatuseservice = new StudentCurrentStatuseservice();
        classesStudentMappingservice classesStudentMappingservice = new classesStudentMappingservice();
        AuthorityDetailTblservice AuthorityDetailTblservice = new AuthorityDetailTblservice();
        Branchservice branchservice = new Branchservice();
        sectionservice sectionservice = new sectionservice();
        Sessionservice sessionservice = new Sessionservice();
        Termservice termservice = new Termservice();
        Studentservice studentservice = new Studentservice();
        Categoryservice categoryservice = new Categoryservice();
        Programdegreesservice programdegreesservice = new Programdegreesservice();


        classservice classservice = new classservice();


        classservice Classservice = new classservice();

       
        

        public JsonResult uploadpics(allpics allpics)
        {
            var piclist = new List<allpics>();

            JsonResult objjson = new JsonResult();
            var files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                var picfile = files[i];
                var pathimages = Server.MapPath("~/images/");
                var filenames = Guid.NewGuid() + Path.GetExtension(picfile.FileName);
                var fileName = pathimages + filenames;
                picfile.SaveAs(fileName);
                allpics.url = filenames;
                
            }
            piclist.Add(allpics);
            objjson.Data = piclist;
            var _context = new SMSContext();
            _context.allpics.Add(allpics);
            _context.SaveChanges();
            return objjson;


        }
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student Student)
        {
            if (Student.imagefile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(Student.imagefile.FileName);
                string extentsion = Path.GetExtension(Student.imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
                Student.Admissionimage = "~/images/" + filename;
                filename = Path.Combine(Server.MapPath("/images/"), filename);
                Student.imagefile.SaveAs(filename);
                Studentservice studentservice = new Studentservice();
                studentservice.savestudent(Student);

            }
            else

            {

                Student.Admissionimage = "download.png";


           

            Studentservice service = new Studentservice();
            service.savestudent(Student);
            }
            return RedirectToAction("AssignClass", new { studentroll = Student.RollNo, id = Student.ID });







        }

        //download file code

        public ActionResult imagedetails(int id)
        {

            Student s = studentservice.getbyid(id);
            return View(s);


        }

        //public ActionResult downloadfile(int a)
        //{
        //    var getimage = studentservice.getbyid(a);
        //    Student student = new Student();
        //  var   stgimg = student.Admissionimage;
        //    string path = Server.MapPath("~stgimg");
        //    return View(); 

        //}
        public ActionResult EditStudent(int id)
        {
            Studentservice service = new Studentservice();
            var Student = service.getbyid(id);
            TempData["imgpath"] = Student.Admissionimage;
            return View(Student);
        }
        [HttpPost]
        public ActionResult EditStudent(Student Student)
        {
            if (Student.imagefile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(Student.imagefile.FileName);
                string extentsion = Path.GetExtension(Student.imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
                Student.Admissionimage = "~/images/" + filename;
                filename = Path.Combine(Server.MapPath("/images/"), filename);
                Student.imagefile.SaveAs(filename);
                Studentservice service = new Studentservice();
                service.updateStudent(Student);

            }
            else
            {


                Student.Admissionimage = TempData["imgpath"].ToString();

                Studentservice service = new Studentservice();
                service.updateStudent(Student);

            }
            return RedirectToAction("Studentslist");
        }
        public ActionResult AdmissionForm()
        {
            return View();

        }
        //public ActionResult Assignbranch(string id)
        //{
        //    Branchservice branchservice = new Branchservice();
        //    Studentservice studentservice = new Studentservice();
        //   
        //var emp   = studentservice.getstudent().Where(x => x.RollNo == id).SingleOrDefault();

        // ViewBag.getclass = Classservice.getclasses().ToList();
        //    ViewBag.branchlist = branchservice.getbranch().ToList();
        //    return View(emp);

        //}
        //[HttpPost]
        //public ActionResult Assignbranch(FormCollection fc,string id)


        //{
        //    StudentBranchMapping studentBranchMapping = new StudentBranchMapping();
        //    var classesid= (fc["cboclass"]);
        //    studentBranchMapping.BranchID=Convert.ToInt32((fc["cboBracnh"]));
        //    studentBranchMapping.StudentID = id;
        //    StudentBranchMappingBranchMappingservice studentBranchMappingBranchMappingservice = new StudentBranchMappingBranchMappingservice();
        //    studentBranchMappingBranchMappingservice.saveStudentBranchMapping(studentBranchMapping);
        //    return RedirectToAction("AssignClass",new {classid=classesid , id = studentBranchMapping.StudentID });




        //}
        public ActionResult AssignClass(string studentroll, int id)
        {

            var emp = studentservice.getstudent().Where(x => x.ID == id).SingleOrDefault();
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = Classservice.getclasses().ToList();
            ViewBag.branchlist = branchservice.getbranch().ToList();
            ViewBag.catlist = categoryservice.getCategory().ToList();
            ViewBag.program = programdegreesservice.getProgramdegree().ToList();

            return View(emp);

        }
        [HttpPost]
        public ActionResult AssignClass(FormCollection fc, string studentroll, int id)
        {
            string check =( fc["checkbox"]);
            
            if (check=="on")
            {
                StudentCurrentStatus studentCurrentStatus = new StudentCurrentStatus();

                studentCurrentStatus.StudentID = id;
                studentCurrentStatus.BranchID = fc["cboBracnh"];
                studentCurrentStatus.classesID = Convert.ToInt32((fc["cboclass"]));
                studentCurrentStatus.CategoryID = Convert.ToInt32((fc["cbocategory"]));
                studentCurrentStatus.SessionID = Convert.ToInt32((fc["cbosession"]));
                studentCurrentStatus.TermID = Convert.ToInt32((fc["cboterm"]));
                studentCurrentStatus.SectionID = Convert.ToInt32((fc["cbosection"]));
                studentCurrentStatus.ProgramdegreeID = Convert.ToInt32(fc["cboprogram"]);
                StudentCurrentStatuseservice studentCurrentStatuseservice = new StudentCurrentStatuseservice();
                studentCurrentStatuseservice.saveStudentCurrentStatus(studentCurrentStatus);


                return RedirectToAction("DiscountDetails", new
                {

                    stid = studentCurrentStatus.StudentID,
                    branchid = studentCurrentStatus.BranchID,
                    classid = studentCurrentStatus.classesID,
                    sessionid = studentCurrentStatus.SessionID,
                    cateid = studentCurrentStatus.CategoryID,
                    sectionid = studentCurrentStatus.SessionID,
                    Termid = studentCurrentStatus.TermID,
                    feevtype = 1
                });

            }
            else
            {
                StudentCurrentStatus studentCurrentStatus = new StudentCurrentStatus();

                studentCurrentStatus.StudentID = id;
                studentCurrentStatus.BranchID = fc["cboBracnh"];
                studentCurrentStatus.classesID = Convert.ToInt32((fc["cboclass"]));
                studentCurrentStatus.CategoryID = Convert.ToInt32((fc["cbocategory"]));
                studentCurrentStatus.SessionID = Convert.ToInt32((fc["cbosession"]));
                studentCurrentStatus.TermID = Convert.ToInt32((fc["cboterm"]));
                studentCurrentStatus.SectionID = Convert.ToInt32((fc["cbosection"]));
                studentCurrentStatus.ProgramdegreeID = Convert.ToInt32(fc["cboprogram"]);

                StudentCurrentStatuseservice studentCurrentStatuseservice = new StudentCurrentStatuseservice();
                studentCurrentStatuseservice.saveStudentCurrentStatus(studentCurrentStatus);


                return RedirectToAction("Studentsclasslist");


            }



        }
        
        public ActionResult StudentHeadDiscount(int sid, int  bid, int  cid, int seid, int  ctid, int  secid, int  trid, int vid, int dis)
        {


            SMSContext _context = new SMSContext();
            ViewBag.vid = vid;
            ViewBag.getsid = sid;
            ViewBag.gettrid = trid;
            ViewBag.disid = dis;
            var fkid = (from id in _context.feeScheduleStructures.ToList()

                        where (id.FeeVoucherTypeCode == vid && id.FVBranchCode == bid && id.FVClassCode == cid

                         && id.FVSessionCode == seid
                         && id.FVCategoryCode == ctid
                         && id.FVSectionCode == secid
                        && id.FVTermCode == trid

)
                        select id.FeeStrID).First();
         

            var list = from n in _context.FeeVoucherHeadDetails.Where(x => x.fk_strif == fkid).ToList()
                       join c in _context.subHead3Codes.ToList() on n.SubHead3Code equals c.SubHeadCode3
                     

                     

                       select new discountvm
                       {
                        FeeVoucherHeadDetail=n,
                           SubHead3Code = c

                       };
            ViewBag.getlink="sid=" + sid +  "&"   +   "bid=" + bid+ "&"    +"cid="  +cid+    "&"+ "seid="+secid+"&" +"ctid="+cid+"&"+"secid="+secid+"&"+"trid="+trid+"&"+"vid="+2+"&"+"dis="+dis;
            ViewBag.getlink2 = "sid=" + sid +  "&"   +   "bid=" + bid+ "&"    +"cid="  +cid+    "&"+ "seid="+secid+"&" +"ctid="+cid+"&"+"secid="+secid+"&"+"trid="+trid+"&"+"vid="+1+"&"+"dis="+dis;



             return View(list);

           

        }
        [HttpPost]
        public ActionResult StudentHeadDiscount(FormCollection fc,Discounttbl discounttbl)
        {
            SMSContext _context = new SMSContext();
            
            string[] ids = fc["discountAmount"].Split(',');
            string[] code = fc["HeadValue"].Split(',');
            {
                foreach (var tuple in ids.Zip(code, (x, y) => (ids: x, code: y)))

                {
                   
                    discounttbl.discountAmount =Convert.ToDecimal( tuple.ids);

                    discounttbl.headcode =Convert.ToInt32( tuple.code);
                   
                    
                   

                    _context.discounttbls.Add(discounttbl);
                    _context.SaveChanges();
                }

             

                return RedirectToAction("Studentsclasslist");
            }
        }
        public ActionResult StudentHeadDiscountList()
        {
           
              FeeVoucherTypeservice feeVoucherTypeservice = new FeeVoucherTypeservice();
            SubHead3Codeservice subHead3Codeservice = new SubHead3Codeservice();
            SMSContext sMSContext = new SMSContext();
           var list = from n in sMSContext.discounttbls.ToList()
                                     join db in termservice.getTerm() on n.tmId equals db.id
                                     join feev in feeVoucherTypeservice.getFeeVoucherType() on n.vocid equals feev.FeeVoucherTypeCode
                                     join sub in subHead3Codeservice.getSubHead3Code() on n.headcode equals   sub.SubHeadCode3
                                     join stud in studentservice.getstudent() on n.Stdid equals stud.ID
                                     select new discountviewVm
                                     {
                                       discounttbl=n,
                                       term=db,
                                       FeeVoucherType=feev,
                                       Head3Code=sub,
                                      student=stud
                                       



                                     };



            return View(list);

        }

        public ActionResult StudentHeadDiscountupdate(int studentid, int termid, int vocid, int headco)
        {
            SMSContext _Context = new SMSContext();
      var discounttbl =_Context.discounttbls.Where(x => x.Stdid == studentid && x.tmId == termid && x.vocid == vocid && x.headcode == headco).Single();
            return View(discounttbl);
        }
        [HttpPost]
        public ActionResult StudentHeadDiscountupdate(Discounttbl discounttbl)
        {
            SMSContext _Context = new SMSContext();
            _Context.Entry(discounttbl).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
            return RedirectToAction("StudentHeadDiscountList");

        }
        public ActionResult Studentslist()
        {


            var model = studentservice.getstudent().ToList();       
      
            return View(model);
        }
        public ActionResult Editclasses(int id)
        {
           StudentCurrentStatuseservice service = new StudentCurrentStatuseservice();
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = Classservice.getclasses().ToList();
            ViewBag.branchlist = branchservice.getbranch().ToList();
            ViewBag.catlist = categoryservice.getCategory().ToList();
            ViewBag.program = programdegreesservice.getProgramdegree().ToList();
            var Studentclasses = service.getbyid(id);
            return View(Studentclasses);
        }
        [HttpPost]
        public ActionResult Editclasses(FormCollection fc,int id)
        {
            StudentCurrentStatus StudentCurrentStatus = new StudentCurrentStatus();
            StudentCurrentStatus.id = id;
            StudentCurrentStatus.StudentID =Convert.ToInt32(fc["StudentID"]);
            StudentCurrentStatus.SectionID = Convert.ToInt32((fc["cbosession"]));
            StudentCurrentStatus.classesID = Convert.ToInt32((fc["cboclass"]));
            StudentCurrentStatus.SessionID = Convert.ToInt32((fc["cbosection"]));
            StudentCurrentStatus.TermID = Convert.ToInt32((fc["cboterm"]));
            StudentCurrentStatus.BranchID =fc["cbobranch"];
            StudentCurrentStatus.CategoryID = Convert.ToInt32((fc["cbocateogry"]));
            StudentCurrentStatus.ProgramdegreeID = Convert.ToInt32(fc["Programdegree"]);



            StudentCurrentStatuseservice StudentCurrentStatuseservice = new StudentCurrentStatuseservice();
            StudentCurrentStatuseservice.updateStudentCurrentStatus(StudentCurrentStatus);
            return RedirectToAction("Studentsclasslist");
        }




        public ActionResult DiscountDetails(int stid, int branchid, int classid, int sessionid, int cateid, int sectionid, int Termid, int feevtype)
        {
            SMSContext sMSContext = new SMSContext();
            Discounttbl discounttbl = new Discounttbl();

            int stids = stid;

         var getid = sMSContext.discounttbls.ToList().Where
                         (x => x.Stdid == stids).ToList();
           


            if (getid.Count()==0)
            {


                FeeVoucherTypeservice feeVoucherTypeservice = new FeeVoucherTypeservice();
                SMSContext _context = new SMSContext();
                ViewBag.authordata = AuthorityDetailTblservice.getAuthorityDetailTbl().ToList();
                ViewBag.getvoucher = feeVoucherTypeservice.getFeeVoucherType().ToList();
                return View();
            }
            else
            {
               
                
                return RedirectToAction("AlreadyDiscount");

            }
        }

        
        [HttpPost]
        public ActionResult DiscountDetails(FormCollection fc,DiscountAdvancetbl discountAdvancetbl, int stid, int branchid, int classid, int sessionid, int cateid, int sectionid, int Termid, int feevtype)
        {
           
                 DiscountAdvancetblservice  DiscountAdvancetblservice = new DiscountAdvancetblservice();
     
          
            // string filename = Path.GetFileNameWithoutExtension(discountAdvancetbl.imagefile.FileName);
            // string extentsion = Path.GetExtension(discountAdvancetbl.imagefile.FileName);
            // filename = filename + DateTime.Now.ToString("yymmssfff") + extentsion;
            // discountAdvancetbl.Refimge = "~/images/" + filename;
            // filename = Path.Combine(Server.MapPath("/images/"), filename);
            //dis.imagefile.SaveAs(filename);
            discountAdvancetbl.StudentID = stid;
            DiscountAdvancetblservice.saveDiscountAdvancetblservice(discountAdvancetbl);
            return RedirectToAction("StudentHeadDiscount",
             new
             {
                 sid = stid,
                 bid = branchid,
                 cid = classid,
                 seid = sessionid,
                 ctid = cateid,
                 secid = sectionid,
                 trid = Termid,
                 vid = discountAdvancetbl.VouchertypeID,
                 dis = discountAdvancetbl.Id



             }   
                );


        
        }
        public ActionResult AlreadyDiscount()
        {

            return View();
        }
        public ActionResult Studentsclasslist()
        {


            var model = from c in StudentCurrentStatuseservice.getStudentCurrentStatus()
                        join s in studentservice.getstudent() on c.StudentID equals s.ID
                        join sec in sectionservice.getsection() on c.SectionID equals sec.id
                        join Session in sessionservice.getsession() on c.SessionID equals Session.ID
                        join classes in classservice.getclasses() on c.classesID equals classes.ID
                        join term in termservice.getTerm() on c.TermID equals term.id
                        join C in categoryservice.getCategory() on c.CategoryID equals C.id
                        join setV in setVoucherpercentservice.getsetVoucherpercent() on c.StudentID equals setV.Studentcode

                        

                        select new StudentDisplayVM
                        {
                            SetVoucherpercent=setV,
                            section = sec,
                            session = Session,
                            Student = s,
                            StudentCurrentStatus = c,
                            Classes = classes,
                            Category = C,
                            term=term,


                        };


            return View(model);
        }
        public ActionResult Promotion()
        {
            ViewBag.session = sessionservice.getsession().ToList();
            
            ViewBag.classeslist = Classservice.getclasses().ToList();
           
            return View();
        }
        public ActionResult Finepromotionlist()
        {


            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = classservice.getclasses().ToList();
            ViewBag.branchlist = branchservice.getbranch().ToList();
            ViewBag.catlist = categoryservice.getCategory().ToList();
            ViewBag.programall = programdegreesservice.getProgramdegree().ToList();
            
            return View();
        }
        [HttpGet]
        public ActionResult studentsPromotion(int cboclass,int cbosession,int cbocategory,int cboterm,int cbosection,int cboprogram)
        {
            StudentCurrentStatuseservice currentStatuseservice = new StudentCurrentStatuseservice();
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.classeslist = Classservice.getclasses().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            var model = from c in StudentCurrentStatuseservice.getStudentCurrentStatus().ToList().Where(x=>x.classesID==cboclass
                        && x.SessionID==cbosession && x.CategoryID==cbocategory && x.TermID==cboterm 
                        && x.SectionID==cbosection && x.ProgramdegreeID==cboprogram    
                        )
                         join s in studentservice.getstudent() on c.StudentID equals s.ID
                         join sec in sectionservice.getsection() on c.SectionID equals sec.id
                         join Session in sessionservice.getsession() on c.SessionID equals Session.ID
                         join classes in classservice.getclasses() on c.classesID equals classes.ID
                         join term in termservice.getTerm() on c.TermID equals term.id
                       



                        select new StudentDisplayVM
                        {
                            section = sec,
                            session = Session,
                            Student = s,
                            StudentCurrentStatus = c,
                            Classes = classes,
                            term = term

                        };



            return View(model);
        }
        [HttpPost]
        public ActionResult studentsPromotion(FormCollection fc)
        {


            string [] ids =fc["classid"].Split( ',');
            string[] roll = fc["rollno"].Split(',');

            string[] sessionid = fc["cbosession"].Split(',');
            string[] clas = fc["cboclass"].Split(',');
            string[] cat = fc["cat"].Split(',');
            string[] pid = fc["pid"].Split(',');
            int clases = Convert.ToInt32(clas[0]);
            int cates = Convert.ToInt32(cat[0]);
            int pids = Convert.ToInt32(pid[0]);
           
            IEnumerable<Tuple<string, string, string>> result = ids
    .Zip(roll, (e1, e2) => new { e1, e2 })
    .Zip(sessionid, (z1, e3) => Tuple.Create(z1.e1, z1.e2, e3));
            foreach (var tuple in result)
            
            {
                StudentCurrentStatus stdcurent = new StudentCurrentStatus();
                    //classesStudentMapping classesStudentMapping = new classesStudentMapping();

                    var product =StudentCurrentStatuseservice.getbyid(Convert.ToInt32(tuple.Item1));
                 
                    //classesStudentMapping.StudentID =rols;
                    //classesStudentMapping.id = Convert.ToInt32(tuple.ids);
                    stdcurent.id= Convert.ToInt32(tuple.Item1);
                stdcurent.StudentID =Convert.ToInt32( tuple.Item2);
                stdcurent.SessionID = Convert.ToInt32(tuple.Item3);
                stdcurent.CategoryID = cates;

                stdcurent.TermID = Convert.ToInt32(fc["tids"]);
                
                stdcurent.classesID = clases;
                stdcurent.SectionID = Convert.ToInt32(fc["sid"]); ;
                stdcurent.ProgramdegreeID = pids;
                stdcurent.BranchID = Convert.ToString(1);
             
                   StudentCurrentStatuseservice.updateStudentCurrentStatus(stdcurent);
                Masterstudentcurrentstatus masterstudentcurrentstatus = new Masterstudentcurrentstatus();
                masterstudentcurrentstatus.classesID = clases;
                masterstudentcurrentstatus.CategoryID = cates;
                masterstudentcurrentstatus.ProgramdegreeID = pids;
                masterstudentcurrentstatus.SectionID= Convert.ToInt32(fc["sid"]);
                masterstudentcurrentstatus.SessionID = Convert.ToInt32(tuple.Item3);
                masterstudentcurrentstatus.TermID = Convert.ToInt32(fc["tids"]);
                masterstudentcurrentstatus.StudentID= Convert.ToInt32(tuple.Item2);
                masterstudentcurrentstatus.date = DateTime.Now;
                SMSContext sMSContext =  new SMSContext();
                sMSContext.masterstudentcurrentstatuses.Add(masterstudentcurrentstatus);
                ViewBag.name ="studentsPromotion?cboclass=" + stdcurent.classesID+"&"+"cbosession="+stdcurent.SessionID+"&"+"cbocategory="+stdcurent.CategoryID+"&"+"cboterm="+stdcurent.TermID+"&"+"cbosection="+ stdcurent.SectionID + "&"+ "cboprogram="+stdcurent.ProgramdegreeID;
                sMSContext.SaveChanges();
                



            }
            

            return Redirect(ViewBag.name);



        }
        public ActionResult allsemesterRecords()
        {
            SMSContext sMSContext = new SMSContext();
            ViewBag.session = sessionservice.getsession().ToList();
          
            ViewBag.getclass = Classservice.getclasses().ToList();
            return View();


        }

        public ActionResult allsemesterRecord(int cboclass,int cbosession)
        {

            ViewBag.link="cboclass="+cboclass+"&&"+"cbosession="+cbosession;
            SMSContext sMSContext = new SMSContext();
            var alls = from c in sMSContext.allSemesterfeesRecord.ToList().Where(x => x.classes == cboclass && x.session == cbosession)
                       join s in studentservice.getstudent() on c.studentId equals s.ID
                       join cl in Classservice.getclasses() on c.classes equals cl.ID
                       join se in sessionservice.getsession() on c.session equals se.ID
                       select new allsemesterRecords
                       {

                           allSemesterfeesRecord = c,
                           student = s,
                           classes = cl,
                           session = se,
                         


                     };
            return View(alls);


        }


    }
   
    //public ActionResult feespackage(string id)


    //{

    //    return View();
    //}

}
