using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
    public class Studentclassresult
    {
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string TermName { get; set; }
        public string sectionName { get; set; }
        public string classname { get; set; }
        public string Sessionname { get; set; }
        public decimal AssignmentMakrs { get; set; }
        public decimal FinalTerm { get; set; }
        public decimal MidMarks { get; set; }
    }
}
