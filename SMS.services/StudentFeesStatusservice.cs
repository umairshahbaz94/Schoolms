using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class StudentFeesStatusservice
    {


        public List<StudentFeesStatus> getStudentFeesStatus()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.StudentFeesStatuses.ToList();
        }
        public void saveStudentFeesStatus(StudentFeesStatus StudentFeesStatus)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.StudentFeesStatuses.Add(StudentFeesStatus);
            sMSContext.SaveChanges();
        }
        public StudentFeesStatus getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();


            return sMSContext.StudentFeesStatuses.Find(id);
        }
        public bool updateStudentFeesStatus(StudentFeesStatus StudentFeesStatus)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(StudentFeesStatus).State = System.Data.Entity.EntityState.Modified;
            return sMSContext.SaveChanges() > 0;
        }

    }
}
