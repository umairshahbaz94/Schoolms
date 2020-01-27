using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class courseclassmapping
    {

        public int id { get; set; }
        public int Subjectsid { get; set; }
        public int classesId{ get; set; }
        public DateTime date { get; set; }
    }
}
