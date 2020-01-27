using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public  class Sessionservice
    {



        public void saveSession(Session Session)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Sessions.Add(Session);
            sMSContext.SaveChanges();
        }
        public Session getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Sessions.Find(id);
        }
        public List<Session> getsession()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Sessions.ToList();
        }
        public void updateSession(Session Session)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(Session).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }

    }

}
