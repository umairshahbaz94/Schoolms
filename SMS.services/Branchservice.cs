using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
  public  class Branchservice

    {



        public void savebranch(Branch branch)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Branchs.Add(branch);
            sMSContext.SaveChanges();
        }
        public Branch getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Branchs.Find(id);
        }
        public void updatebranch(Branch branch)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(branch).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
        public List<Branch> getbranch()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Branchs.ToList();
        }

    }


}
