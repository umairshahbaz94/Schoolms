using SMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public   class StudentCurrentStatuseservice
    {
        public List< StudentCurrentStatus> getStudentCurrentStatus()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext. StudentCurrentStatuses.ToList();
        }
        
        public void saveStudentCurrentStatus( StudentCurrentStatus  StudentCurrentStatus)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext. StudentCurrentStatuses.Add( StudentCurrentStatus);
            sMSContext.SaveChanges();
        }
        public  StudentCurrentStatus getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();


            return sMSContext. StudentCurrentStatuses.Find(id);
        }
        public IEnumerable <StudentCurrentStatus> getbyid2(int id)
        {
            SMSContext sMSContext = new SMSContext();


            return sMSContext.StudentCurrentStatuses.Where(x=>x.StudentID==id);
        }
        public void updateStudentCurrentStatus( StudentCurrentStatus  StudentCurrentStatus)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry( StudentCurrentStatus).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }

    }
}
