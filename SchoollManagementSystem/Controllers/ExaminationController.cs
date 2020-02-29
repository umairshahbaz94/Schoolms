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
    public class ExaminationController : Controller
    {

        ResultSheetService ResultSheetService = new ResultSheetService();
        sectionservice sectionservice = new sectionservice();
        Sessionservice sessionservice = new Sessionservice();
        Termservice termservice = new Termservice();
        Studentservice studentservice = new Studentservice();
        Subjectservice Subjectservice = new Subjectservice();
        classservice classservice = new classservice();
        configfilesService configfilesService = new configfilesService();
        Teacherservice teacherservice = new Teacherservice();
        teachersubjectCourseService teachersubjectCourseService = new teachersubjectCourseService();
        Classsubjectmappingservice classsubjectmappingservice = new Classsubjectmappingservice();
        // GET: Examination

        public ActionResult configfiles()
        {

            return View();

        }
        [HttpPost]
        public ActionResult configfiles(configfile configfile)
        {
            configfile.Updatetime = DateTime.Now;
            configfilesService.saveconfigfile(configfile);


            return View();

        }

        [HttpGet]
        public ActionResult addsubject()
        {


            return View();

        }

        [HttpPost]
        public ActionResult addsubject(Subjects subjects)
        {
            subjects.date = DateTime.Now;
            Subjectservice.saveSubjects(subjects);

            return View();

        }

        public ActionResult addTeachercourse()

        {
            ViewBag.classcourse = from classcourse in classsubjectmappingservice.getcourseclassmappings().ToList()
                                  join subject in Subjectservice.getSubjects().ToList() on classcourse.Subjectsid equals subject.Id
                                  select new classcoursevm
                                  {
                                      id = classcourse.id,
                                      coursename = subject.SubjectName,

                                  };
            ViewBag.teacher = teacherservice.getTeachers().ToList();

            return View();
        }
        [HttpPost]
        public ActionResult addTeachercourse(teachersubjectCourse teachersubjectCourse)

        {
            teachersubjectCourse.date = DateTime.Now;
            teachersubjectCourseService.saveteachersubjectCourses(teachersubjectCourse);

            return View();
        }

        [HttpGet]
        public ActionResult addTeacher()
        {


            return View();

        }
        [HttpPost]
        public ActionResult addTeacher(Teacher teacher)
        {
            teacher.Addteacherdate = DateTime.Now;
            teacherservice.saveTeachers(teacher);

            return View();

        }
        [HttpGet]
        public ActionResult classcourseradd()
        {

            ViewBag.subject = Subjectservice.getSubjects().ToList();
            ViewBag.classs = classservice.getclasses().ToList();
            return View();

        }
        [HttpPost]
        public ActionResult classcourseradd(FormCollection fc)
        {
            courseclassmapping courseclassmapping = new courseclassmapping();
            courseclassmapping.classesId = Convert.ToInt32(fc["cboclass"]);
            courseclassmapping.Subjectsid = Convert.ToInt32(fc["cbosubject"]);
            courseclassmapping.date = DateTime.Now;
            classsubjectmappingservice.savecourseclassmappings(courseclassmapping);

            return View();

        }
        public ActionResult FindallStudentResults()
        {
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = classservice.getclasses().ToList();
            ViewBag.subject = Subjectservice.getSubjects().ToList();


            return View();
        }

        [HttpGet]
        public ActionResult AddResult(int cboclass, int cbosession, int cboterm, int cbosection, int cbosubject)

        {

            var id = ResultSheetService.getResultSheet().Where(x => x.classesID == cboclass && x.SessionsID == cbosession &&
             x.TermsID == cboterm && x.SectionID == cbosection && x.Subjectid == cbosubject).Select(x => x.ID);


            if (id.Count() > 0)
            {


                return RedirectToAction("Edit", new { cboclass, cbosection, cbosession, cbosubject, cboterm });

            }
            else
            {
                StudentCurrentStatuseservice currentStatuseservice = new StudentCurrentStatuseservice();
                ViewBag.session = sessionservice.getsession().ToList();
                ViewBag.classeslist = classservice.getclasses().ToList();
                ViewBag.section = sectionservice.getsection().ToList();
                ViewBag.termname = termservice.getTerm().ToList();
                ViewBag.subject = cbosubject;

                var model = from c in currentStatuseservice.getStudentCurrentStatus().ToList().Where(x => x.classesID == cboclass
                            && x.SessionID == cbosession && x.TermID == cboterm
                            && x.SectionID == cbosection
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

        }

        [HttpGet]
        public ActionResult edit(int cboclass, int cbosession, int cboterm, int cbosection, int cbosubject)


        {
            ViewBag.subject = cbosubject;
            var list = from r in ResultSheetService.getResultSheet().Where(x => x.classesID == cboclass && x.SessionsID == cbosession &&
      x.TermsID == cboterm && x.SectionID == cbosection && x.Subjectid == cbosubject).ToList()
                       join s in studentservice.getstudent() on r.Studentid equals s.ID
                       join sec in sectionservice.getsection() on r.SectionID equals sec.id
                       join Session in sessionservice.getsession() on r.SessionsID equals Session.ID
                       join classes in classservice.getclasses() on r.classesID equals classes.ID
                       join term in termservice.getTerm() on r.TermsID equals term.id



                       select new StudentDisplayVM
                       {
                           section = sec,
                           session = Session,
                           Student = s,
                           result = r,
                           Classes = classes,
                           term = term


                       };




            return View(list);
        }
        [HttpPost]
        public ActionResult edit(FormCollection fc)

        {


            //string[] ids = fc["classid"].Split(',');
            string[] assimarks = fc["AssignmentMakrs"].Split(',');
            string[] rollno = fc["rollno"].Split(',');
            string[] finall = fc["FinalTerm"].Split(',');
            string[] midterm = fc["MidMarks"].Split(',');



            string[] id = fc["classid"].Split(',');
            string[] clas = fc["classesID"].Split(',');
            string[] term = fc["TermsID"].Split(',');
            string[] ses = fc["SessionsID"].Split(',');
            string[] sec = fc["SectionID"].Split(',');
            string[] sub = fc["ID"].Split(',');

            int clases = Convert.ToInt32(clas[0]);
            int terms = Convert.ToInt32(term[0]);

            int sess = Convert.ToInt32(ses[0]);
            int subs = Convert.ToInt32(sub[0]);
            int secs = Convert.ToInt32(sub[0]);
            int a = -1;
            Tuple<string[], string[], string[], string[]>[] statesData =
            { Tuple.Create(finall, assimarks, rollno,id)};
            //IEnumerable<Tuple<string, string, string, string, string>> result = assimarks
            //    .Zip(rollno, (e1, e2) => new { e1, e2 })
            //    .Zip(assimarks, (e4, e5) => new { e4, e5 })
            //    .Zip(finall, (z1, e5) => Tuple.Create(z1.e4,z1.e4,z1.e4,z1.e4))
            var tuple = new Tuple<string[], string[], string[], string[]>(finall, assimarks, rollno, id);

            for (int i = 0; i < ses.Length; i++)
            {
                assimarks[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Id => Convert.ToString((Id))).ToList();
                id[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Id => Convert.ToString((Id))).ToList();
                finall[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Id => Convert.ToString((Id))).ToList();
                midterm[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Id => Convert.ToString((Id))).ToList();





                ResultSheet resultSheet = new ResultSheet();
                resultSheet.AssignmentMakrs = Convert.ToDecimal(assimarks[i]);
                resultSheet.Studentid = Convert.ToInt32(rollno[i]);
                resultSheet.MidMarks = Convert.ToDecimal(midterm[i]);
                resultSheet.TermsID = terms;
                resultSheet.classesID = clases;
                resultSheet.SectionID = secs;
                resultSheet.SessionsID = sess;
                resultSheet.FinalTerm = Convert.ToDecimal(finall[i]);
                resultSheet.Subjectid = subs;
                resultSheet.ID = Convert.ToInt32(id[i]);
                resultSheet.AddDetails = DateTime.Now;
                SMSContext sMSContext = new SMSContext();
                ResultSheetService.updateResultSheet(resultSheet);
                sMSContext.SaveChanges();

            }



            return RedirectToAction("FindallStudentResults");
        }

        [HttpPost]
        public ActionResult AddResult(FormCollection fc)

        {

            //string[] ids = fc["classid"].Split(',');
            string[] ids = fc["AssignmentMakrs"].Split(',');
            string[] roll = fc["rollno"].Split(',');
            string[] finall = fc["FinalTerm"].Split(',');



            string[] sessionid = fc["MidMarks"].Split(',');
            string[] clas = fc["classesID"].Split(',');
            string[] term = fc["TermsID"].Split(',');
            string[] ses = fc["SessionsID"].Split(',');
            string[] sec = fc["SectionID"].Split(',');
            string[] sub = fc["ID"].Split(',');

            int clases = Convert.ToInt32(clas[0]);
            int terms = Convert.ToInt32(term[0]);

            int sess = Convert.ToInt32(ses[0]);
            int subs = Convert.ToInt32(sub[0]);
            int secs = Convert.ToInt32(sub[0]);

            IEnumerable<Tuple<string, string, string>> result = ids
      .Zip(roll, (e1, e2) => new { e1, e2 })
      .Zip(sessionid, (z1, e3) => Tuple.Create(z1.e1, z1.e2, e3));
            foreach (var tuple in result)

            {
                ResultSheet resultSheet = new ResultSheet();

                resultSheet.AssignmentMakrs = Convert.ToInt32(tuple.Item1);
                resultSheet.Studentid = Convert.ToInt32(tuple.Item2);
                resultSheet.MidMarks = Convert.ToInt32(tuple.Item3);
                resultSheet.TermsID = terms;
                resultSheet.classesID = clases;
                resultSheet.SectionID = secs;
                resultSheet.SessionsID = sess;
                resultSheet.FinalTerm = 10;
                resultSheet.Subjectid = subs;
                resultSheet.AddDetails = DateTime.Now;
                SMSContext sMSContext = new SMSContext();
                sMSContext.ResultSheet.Add(resultSheet);
                sMSContext.SaveChanges();


            }



            return RedirectToAction("FindallStudentResults");
        }


        public ActionResult FindclassResult()
        {
            ViewBag.session = sessionservice.getsession().ToList();
            ViewBag.section = sectionservice.getsection().ToList();
            ViewBag.termname = termservice.getTerm().ToList();
            ViewBag.getclass = classservice.getclasses().ToList();
            ViewBag.subject = Subjectservice.getSubjects().ToList();

            return View();
        }


        public ActionResult ClassStudentList(int cboclass, int cbosession, int cboterm, int cbosection, int cbosubject)

        {
            ViewBag.id="cboclass="+cboclass+"&"+"cboterm="+cboterm+"&"+"cbosection="+cbosection+"&"+"cbosubject="+cbosubject+"&"+"cbosession="+cbosession;
            ViewBag.subjectname = Subjectservice.getSubjects().Where(x => x.Id == cbosubject).Select(x => x.SubjectName).SingleOrDefault();
            ViewBag.classname = classservice.getclasses().Where(x => x.ID == cboclass).Select(x => x.classname).SingleOrDefault();
            ViewBag.section = sectionservice.getsection().Where(x => x.id == cbosection).Select(y => y.sectionName).SingleOrDefault();
            var list = from Result in ResultSheetService.getResultSheet().ToList().Where(x => x.classesID == cboclass && x.SessionsID == cbosession
               && x.TermsID == cboterm && x.SectionID == cbosection && x.Subjectid == cbosubject)
                       join term in termservice.getTerm() on Result.TermsID equals term.id
                       join classs in classservice.getclasses() on Result.classesID equals classs.ID
                       join student in studentservice.getstudent() on Result.Studentid equals student.ID
                       join Subjectservice in Subjectservice.getSubjects() on Result.Subjectid equals Subjectservice.Id 
                       select new StudentDisplayVM
                       {

                           result = Result,
                           term = term,
                           Classes = classs,
                           student = student,
                           subjects=Subjectservice,
                       };
            return View(list);
        }
        public ActionResult gradereport()
        {
            var list = configfilesService.getconfigfile();

                   
                


            return View();
                }
    }
}

