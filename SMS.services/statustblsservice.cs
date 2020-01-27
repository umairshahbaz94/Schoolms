using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class statustblsservice
    {
        public List<statustbl> getstatustbls()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.statustbls.ToList();
        }
        public void savestatustbls(statustbl statustbls)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.statustbls.Add(statustbls);
            sMSContext.SaveChanges();
        }
        public statustbl getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();


            return sMSContext.statustbls.Find(id);
        }
        public void updatestatustbls(statustbl statustbls)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(statustbls).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}
