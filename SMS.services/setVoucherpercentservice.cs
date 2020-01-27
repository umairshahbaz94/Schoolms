using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class setVoucherpercentservice
    {
         public void savesetVoucherpercent(setVoucherpercent setVoucherpercent)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.setVoucherpercent.Add(setVoucherpercent);
            sMSContext.SaveChanges();
        }
        public setVoucherpercent getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.setVoucherpercent.Find(id);
        }
        public void updatesetVoucherpercent(setVoucherpercent setVoucherpercent)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(setVoucherpercent).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<setVoucherpercent> getsetVoucherpercent()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.setVoucherpercent.ToList();
        }

    }
}
