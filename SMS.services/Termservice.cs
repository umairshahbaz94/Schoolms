using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class Termservice
    {


        public List<Term> getTerm()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Terms.ToList();
        }
        public void saveTerm(Term Term)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Terms.Add(Term);
            sMSContext.SaveChanges();
        }
        public Term getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Terms.Find(id);
        }
        public void updateTerm(Term Term)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(Term).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}
