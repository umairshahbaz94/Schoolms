using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class Classsubjectmappingservice
    {
        public List<courseclassmapping> getcourseclassmappings()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.courseclassmapping.ToList();
        }
        public void savecourseclassmappings(courseclassmapping courseclassmappings)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.courseclassmapping.Add(courseclassmappings);
            sMSContext.SaveChanges();
        }
        public courseclassmapping getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.courseclassmapping.Find(id);
        }
        public void updatecourseclassmappings(courseclassmapping courseclassmappings)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(courseclassmappings).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}
