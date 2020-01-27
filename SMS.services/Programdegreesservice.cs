using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class Programdegreesservice 
    {
        public void saveProgramdegree(Programdegree Programdegree)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Programdegree.Add(Programdegree);
            sMSContext.SaveChanges();
        }
        public Programdegree getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Programdegree.Find(id);
        }
        public void updateProgramdegree(Programdegree Programdegree)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(Programdegree).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<Programdegree> getProgramdegree()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Programdegree.ToList();
        }
    }
}
