using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class sectionservice
    {
        public List<Section> getsection()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Section.ToList();
        }
        public void savesection(Section section)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Section.Add(section);
            sMSContext.SaveChanges();
        }
        public Section getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Section.Find(id);
        }
        public void updatesection(Section section)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(section).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }


    }
}
