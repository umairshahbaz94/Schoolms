using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class FeeScheduleStructureservice
    {
        public void saveFeeScheduleStructure( FeeScheduleStructure  FeeScheduleStructure)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.feeScheduleStructures.Add( FeeScheduleStructure);
            sMSContext.SaveChanges();
        }
        public  FeeScheduleStructure getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.feeScheduleStructures.Find(id);
        }
        public void updateFeeScheduleStructure( FeeScheduleStructure  FeeScheduleStructure)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry( FeeScheduleStructure).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List< FeeScheduleStructure> getFeeScheduleStructure()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.feeScheduleStructures.ToList();
        }
    }
}

