using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class DiscountAdvancetblservice
    {


        public void saveDiscountAdvancetblservice(DiscountAdvancetbl DiscountAdvancetbl)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.discountAdvancetbls.Add(DiscountAdvancetbl);
            sMSContext.SaveChanges();
        }
        public DiscountAdvancetbl getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.discountAdvancetbls.Find(id);
        }
        public void updateDiscountAdvancetbl(DiscountAdvancetbl DiscountAdvancetbl)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(DiscountAdvancetbl).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<DiscountAdvancetbl> getDiscountAdvancetbl()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.discountAdvancetbls.ToList();
        }
    }
}
