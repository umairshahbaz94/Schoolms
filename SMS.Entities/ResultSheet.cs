using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class ResultSheet
    {
        public int ID { get; set; }
        public int Studentid  { get; set; }
        public int Programdegreesid { get; set; }
        public int Subjectid { get; set; }
        public int SectionID { get; set; }
        public int SessionsID { get; set; }
        public int classesID { get; set; }
        public int TermsID { get; set; }
        public decimal AssignmentMakrs { get; set; }
        public decimal MidMarks { get; set; }
        public decimal FinalTerm { get; set; }
        public DateTime ? AddDetails{ get; set; }
        public DateTime ? Deletedetails { get; set; }
        public DateTime? Updatedetails { get; set; }
        public string Grade { get; set; }
        public decimal Point  { get; set; }


    }
}
