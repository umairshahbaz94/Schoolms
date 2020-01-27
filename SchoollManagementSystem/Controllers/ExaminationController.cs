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
        sectionservice sectionservice = new sectionservice();
        Sessionservice sessionservice = new Sessionservice();
        Termservice termservice = new Termservice();
        Studentservice studentservice = new Studentservice();
        Subjectservice Subjectservice = new Subjectservice();
        classservice classservice = new classservice();
        Teacherservice teacherservice = new Teacherservice();
        Classsubjectmappingservice classsubjectmappingservice = new Classsubjectmappingservice();
        // GET: Examination


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

         ViewBag.subject=   Subjectservice.getSubjects().ToList();
            ViewBag.classs = classservice.getclasses().ToList();
            return View();

        }
        [HttpPost]
        public ActionResult classcourseradd(FormCollection fc)
        {
            courseclassmapping courseclassmapping = new courseclassmapping();
            courseclassmapping.classesId =Convert.ToInt32( fc["cboclass"]);
            courseclassmapping.Subjectsid= Convert.ToInt32(fc["cbosubject"]);
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
        public ActionResult AddResult(int cboclass, int cbosession, int cboterm, int cbosection,int cbosubject)

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
            string[] sub = fc["ID"].Split(',');

            int clases = Convert.ToInt32(clas[0]);
            int terms = Convert.ToInt32(term[0]);

            int sess = Convert.ToInt32(ses[0]);
            int subs = Convert.ToInt32(sub[0]);

            IEnumerable<Tuple<string, string, string>> result = ids
      .Zip(roll, (e1, e2) => new { e1, e2 })
      .Zip(sessionid, (z1, e3) => Tuple.Create(z1.e1, z1.e2, e3));
            foreach (var tuple in result)

            {
                ResultSheet resultSheet = new ResultSheet();
                resultSheet.AssignmentMakrs = Convert.ToInt32(tuple.Item1);
                resultSheet.Studentid = tuple.Item2;
                resultSheet.MidMarks = Convert.ToInt32(tuple.Item3);
                resultSheet.TermsID = terms;
                resultSheet.classesID = clases;
                resultSheet.SessionsID = sess;
                resultSheet.FinalTerm = 10;
                resultSheet.ID =subs;
                resultSheet.AddDetails = DateTime.Now;
                SMSContext sMSContext = new SMSContext();
                sMSContext.ResultSheet.Add(resultSheet);
                sMSContext.SaveChanges();

            }

            return RedirectToAction("FindallStudentResults");
        }

    }
}

