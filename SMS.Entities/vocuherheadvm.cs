using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class vocuherheadvm
    {
        public string Name { get; set; }

        public string branchname { get; set; }
         public string CategoryName { get; set; }

        public string VoucherNO { get; set; }
        public string RollNo { get; set; }
        public string classname { get; set; }
        public string Description { get; set; }
        public string Sessionname { get; set; }
        public string Pname { get; set; }
        public string TermName { get; set; }
        public string sectionName { get; set; }
        public DateTime ? DepositeDate { get; set; }

        public decimal HeadValue { get; set; }

    }
}
