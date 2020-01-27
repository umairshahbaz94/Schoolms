using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
 public   class teachersubjectCourse
    {
        public int id { get; set; }
        public int courseclassmappingid { get; set; }
        public int teacherID { get; set; }
        public DateTime date { get; set; }
    }

}
