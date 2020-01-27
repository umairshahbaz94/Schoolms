using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class Subjects
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string subjectCode { get; set; }
        public int Subjectcridethours{ get; set; }
        public DateTime date { get; set; }
    }
}
