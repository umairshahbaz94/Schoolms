using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class AuthorityDetailTblservice
    {
        public void saveAuthorityDetailTblservice(AuthorityDetailTbl AuthorityDetailTbl)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.authorityDetailTbls.Add(AuthorityDetailTbl);
            sMSContext.SaveChanges();
        }
        public AuthorityDetailTbl getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.authorityDetailTbls.Find(id);
        }
        public void updateAuthorityDetailTbl(AuthorityDetailTbl AuthorityDetailTbl)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(AuthorityDetailTbl).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<AuthorityDetailTbl> getAuthorityDetailTbl()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.authorityDetailTbls.ToList();
        }

    }
}
