using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
public class feesreport
    {
       public string Name { get; set; }
        public string RollNo { get; set; }
        public string classname { get; set; }
        public string CategoryName { get; set; }
        public string sectionName { get; set; }
        public string Sessionname { get; set; }
        public string TermName { get; set; }
        public string FVDueDate { get; set; }
        public string FVAccountTitle { get; set; }
        public string branchname { get; set; }
        public string Description { get; set; }
        public string V2Account { get; set; }
        public string V1Account { get; set; }
        public string FVAccountno { get; set; }
        public decimal HeadValue  { get; set; }
        public decimal discountAmount { get; set; }
        public decimal totalfine { get; set; }

    }

}
