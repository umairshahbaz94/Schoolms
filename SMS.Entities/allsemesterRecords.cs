using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class allsemesterRecords
    {
        public allSemesterfeesRecord allSemesterfeesRecord { get; set; }
        public Student student { get; set; }
        public classes classes { get; set; }
        public Session session { get; set; }
    }
}
