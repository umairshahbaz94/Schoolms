using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.services
{
   public class Categoryservice
    {
        public List<Category> getCategory()
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Categorys.ToList();
        }
        public void saveCategory(Category Category)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Categorys.Add(Category);
            sMSContext.SaveChanges();
        }
        public Category getbyid(int id)
        {
            SMSContext sMSContext = new SMSContext();

            return sMSContext.Categorys.Find(id);
        }
        
            public void updateCategory(Category Category)
        {
            SMSContext sMSContext = new SMSContext();
            sMSContext.Entry(Category).State = System.Data.Entity.EntityState.Modified;
            sMSContext.SaveChanges();
        }
    }
}
