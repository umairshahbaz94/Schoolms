using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class teachersubjectCourseService
    {
        public List<teachersubjectCourse> getteachersubjectCourses()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.teachersubjectCourse.ToList();
        }
        public void saveteachersubjectCourses(teachersubjectCourse teachersubjectCourses)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.teachersubjectCourse.Add(teachersubjectCourses);
            sMSContext.SaveChanges();
        }
        public teachersubjectCourse getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.teachersubjectCourse.Find(id);
        }
        public void updateteachersubjectCourses(teachersubjectCourse teachersubjectCourses)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(teachersubjectCourses).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}
