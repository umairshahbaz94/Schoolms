using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
    public class StudentDisplayVM
    {
        public StudentCurrentStatus StudentCurrentStatus { get; set; }
        public classesStudentMapping classesStudentMapping { get; set; }
        public FeeScheduleStructure FeeScheduleStructure { get; set; }
        public Section section { get; set; }
        public Term term { get; set; }
        public Session session { get; set; }
        public classes Classes { get; set; }
        public Student Student { get; set; }
        public Category Category { get; set; }
        public Branch Branch { get; set; }
        public setVoucherpercent SetVoucherpercent { get; set; }
        public ResultSheet result { get; set; }
        public Student student { get; set; }





    }
}
