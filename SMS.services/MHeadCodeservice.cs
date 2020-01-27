using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class MHeadCodeservice
    {

        public void saveMHeadCode( MHeadCode  MHeadCode)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext. MHeadCodes.Add( MHeadCode);
            sMSContext.SaveChanges();
        }
        public  MHeadCode getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext. MHeadCodes.Find(id);
        }
        public void updateMHeadCode( MHeadCode  MHeadCode)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry( MHeadCode).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List< MHeadCode> getMHeadCode()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext. MHeadCodes.ToList();
        }
    }
}
