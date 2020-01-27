    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
    public class Discounttbl
    {
        public int ID { get; set; }

        public int DisID { get; set; }
        public int Stdid { get; set; }

        public int tmId { get; set; }
       
        public int headcode { get; set; }
        public int vocid { get; set; }
        public virtual SubHead3Code SubHead3Code { get; set; }
        public decimal discountAmount { get; set; }
        public int statusfine { get; set; }
        public int vstatus  { get; set; }
    }
}
