using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class SubHead2Codeservice
    {
        public void saveSubHead2Code(SubHead2Code SubHead2Code)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.subHead2Codes.Add(SubHead2Code);
            sMSContext.SaveChanges();
        }
        public SubHead2Code getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.subHead2Codes.Find(id);
        }
        public void updateSubHead2Code(SubHead2Code SubHead2Code)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(SubHead2Code).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<SubHead2Code> getSubHead2Code()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.subHead2Codes.ToList();
        }
    }
}
