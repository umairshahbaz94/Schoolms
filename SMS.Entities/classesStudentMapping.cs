using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class classesStudentMapping
    {
        public int id { get; set; }
        public string StudentID { get; set; }
        public int SectionID { get; set; }
        public int SessionID { get; set; }
        public int TermID { get; set; }

        public int classesID { get; set; }
        public int BranchID { get; set; }
        public string des { get; set; }





    }
}
