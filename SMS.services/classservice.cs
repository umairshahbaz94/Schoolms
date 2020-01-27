using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public  class  classservice
    {

        public List< classes> getclasses()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.classes.ToList();
        }
        public void saveclasses( classes  classes)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext. classes.Add( classes);
            sMSContext.SaveChanges();
        }
        public  classes getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.classes.Find(id);
        }
        public void updateclasses( classes  classes)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(classes).State = System.Data.Entity.EntityState.Modified;
                sMSContext.SaveChanges();
        }

    }
}
