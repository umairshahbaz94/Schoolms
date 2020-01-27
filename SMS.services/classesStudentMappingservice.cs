using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class classesStudentMappingservice
    {
        public List<classesStudentMapping> getclassesStudentMapping()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.ClassesStudentMappings.ToList();
        }
        public void saveclassesStudentMapping(classesStudentMapping classesStudentMapping)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.ClassesStudentMappings.Add(classesStudentMapping);
            sMSContext.SaveChanges();
        }
        public classesStudentMapping getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();
            

            return sMSContext.ClassesStudentMappings.Find(id);
        }
        public void updateclassesStudentMapping(classesStudentMapping classesStudentMapping)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(classesStudentMapping).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
       
        public int count()
        {
            SMSContext sMSContext = new SMSContext();
            
            return sMSContext.ClassesStudentMappings.Count();
             }
}
}
