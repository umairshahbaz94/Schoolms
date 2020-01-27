using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class fineHeadservice
    {
        public void savefinehead(fineHead finehead)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.fineHead.Add(finehead);
            sMSContext.SaveChanges();
        }
        public fineHead getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.fineHead.Find(id);
        }
        public void updatefinehead(fineHead finehead)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(finehead).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<fineHead> getfinehead()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.fineHead.ToList();
        }
    }
}
