using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class Teacherservice
    {
        public List< Teacher> getTeachers()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext. Teacher.ToList();
        }
        public void saveTeachers( Teacher  Teachers)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext. Teacher.Add( Teachers);
            sMSContext.SaveChanges();
        }
        public  Teacher getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext. Teacher.Find(id);
        }
        public void updateTeachers( Teacher  Teachers)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry( Teachers).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}
