using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
public    class SubHead1Codeservice
    {


        public void saveSubHead1Code(SubHead1Code SubHead1Code)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.subHead1Codes.Add(SubHead1Code);
            sMSContext.SaveChanges();
        }
        public SubHead1Code getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.subHead1Codes.Find(id);
        }
        public void updateSubHead1Code(SubHead1Code SubHead1Code)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(SubHead1Code).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<SubHead1Code> getSubHead1Code()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.subHead1Codes.ToList();
        }
    }
}
