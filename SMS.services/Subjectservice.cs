using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class Subjectservice
    {
        public List<Subjects> getSubjects()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext. Subjects.ToList();
        }
        public void saveSubjects( Subjects  Subjects)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext. Subjects.Add( Subjects);
            sMSContext.SaveChanges();
        }
        public  Subjects getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Subjects.Find(id);
        }
        public void updateSubjects( Subjects  Subjects)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry( Subjects).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}

