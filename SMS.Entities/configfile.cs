using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
 public   class configfile
    {
        public int id { get; set; }
        public string grade { get; set; }
        public decimal Point { get; set; }
        public int highvalue { get; set; }
        public int lowvalue { get; set; }
        public DateTime Updatetime { get; set; }

    }
}
