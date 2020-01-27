using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
public    class discountviewVm
    {

        public Student student { get; set; }
        public Term term { get; set; }
       
        public FeeVoucherType FeeVoucherType { get; set; }
        public Discounttbl discounttbl { get; set; }
        public SubHead3Code Head3Code { get; set; }
    }
}
