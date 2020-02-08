using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class configfilesService
    {
        public List<configfile> getconfigfile()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.configfile.ToList();
        }
        public void saveconfigfile(configfile configfile)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.configfile.Add(configfile);
            sMSContext.SaveChanges();
        }
        public configfile getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.configfile.Find(id);
        }
        public void updateconfigfile(configfile configfile)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(configfile).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }

}
