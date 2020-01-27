using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class SubHead3Codeservice

    {

        public void saveSubHead3Code(SubHead3Code SubHead3Code)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.subHead3Codes.Add(SubHead3Code);
            sMSContext.SaveChanges();
        }
        public SubHead3Code getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.subHead3Codes.Find(id);
        }
        public void updateSubHead3Code(SubHead3Code SubHead3Code)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(SubHead3Code).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<SubHead3Code> getSubHead3Code()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.subHead3Codes.ToList();
        }
    }
}
