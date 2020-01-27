using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
    public class FeeVoucherHeadDetailservice
    {
        public void saveFeeVoucherHeadDetail(FeeVoucherHeadDetail FeeVoucherHeadDetail)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.FeeVoucherHeadDetails.Add(FeeVoucherHeadDetail);
            sMSContext.SaveChanges();
        }
        public FeeVoucherHeadDetail getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.FeeVoucherHeadDetails.Find(id);
        }
        public void updateFeeVoucherHeadDetail(FeeVoucherHeadDetail FeeVoucherHeadDetail)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(FeeVoucherHeadDetail).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<FeeVoucherHeadDetail> getFeeVoucherHeadDetail()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.FeeVoucherHeadDetails.ToList();
        }
    }
}
