using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class Teacher
    {
        public int Id { get; set; }
        public string Teachername { get; set; }
        public string Teachernumber { get; set; }
        public string TeacherAddress { get; set; }
        public DateTime Addteacherdate{ get; set; }
    }
}
