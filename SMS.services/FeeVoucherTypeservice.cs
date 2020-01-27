using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class FeeVoucherTypeservice
    {
        public void saveFeeVoucherType(FeeVoucherType FeeVoucherType)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.FeeVoucherTypes.Add(FeeVoucherType);
            sMSContext.SaveChanges();
        }
        public FeeVoucherType getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.FeeVoucherTypes.Find(id);
        }
        public void updateFeeVoucherType(FeeVoucherType FeeVoucherType)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(FeeVoucherType).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<FeeVoucherType> getFeeVoucherType()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.FeeVoucherTypes.ToList();
        }
    }
}
