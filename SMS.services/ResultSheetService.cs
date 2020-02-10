using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
public class ResultSheetService
    {
        public void saveResultSheet(ResultSheet ResultSheet)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.ResultSheet.Add(ResultSheet);
            sMSContext.SaveChanges();
        }
        public ResultSheet getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.ResultSheet.Find(id);
        }
        public void updateResultSheet(ResultSheet ResultSheet)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(ResultSheet).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<ResultSheet> getResultSheet()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.ResultSheet.ToList();
        }
    }
}
