using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class Studentgrade
    {
        public decimal total { get; set; }
        public string sectionName { get; set; }
        public string SubjectName { get; set; }
        public string classname { get; set; }
        public string Sessionname { get; set; }
        public string TermName { get; set; }
        public string Name { get; set; }
        public int Studentid { get; set; }
        public decimal point { get; set; }
        public string grade { get; set; }

    }
}
