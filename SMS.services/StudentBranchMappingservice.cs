using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  //   StudentBranchMappingBranchMapping.cs
   public class  StudentBranchMappingBranchMappingservice
    {

        public List< StudentBranchMapping> getStudentBranchMapping()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.studentBranchMappings.ToList();
        }
        public void saveStudentBranchMapping( StudentBranchMapping  StudentBranchMapping)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.studentBranchMappings.Add( StudentBranchMapping);
            sMSContext.SaveChanges();
        }
        public  StudentBranchMapping getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext. studentBranchMappings.Find(id);
        }
        public void updatestudentBranchMapping( StudentBranchMapping  StudentBranchMapping)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry( StudentBranchMapping).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}
