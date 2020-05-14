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
    public class AdmissionFormController : Controller
    {
        // GET: AdmissionForm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddStudent()
        {
            return View();
        }
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
    }
}