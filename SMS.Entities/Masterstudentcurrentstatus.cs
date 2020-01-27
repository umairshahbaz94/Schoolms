using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class Masterstudentcurrentstatus
    {
        public int id { get; set; }

        public int StudentID { get; set; }
        public Student student { get; set; }
        public string BranchID { get; set; }

        public int SectionID { get; set; }
        public Section Section { get; set; }
        public int classesID { get; set; }

        public classes Classes { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int SessionID { get; set; }
        public Session Session { get; set; }
        public int TermID { get; set; }
        public Term Term { get; set; }
        public int ProgramdegreeID { get; set; }
        public Programdegree programdegree { get; set; }
        public DateTime date { get; set; }


    }
}
