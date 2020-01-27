using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class Studentservice
    {

        public List<Student> getstudent()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Students.ToList();
        }
        public void savestudent(Student Student)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Students.Add(Student);
            sMSContext.SaveChanges();
        }
        public Student getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Students.Find(id);
        }
        public void updateStudent(Student Student)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(Student).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}
