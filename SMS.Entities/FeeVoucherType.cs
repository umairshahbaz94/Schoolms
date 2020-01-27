using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class FeeVoucherType
    {
        [Key]
       
        public int FeeVoucherTypeCode { get; set; }
        public string feeVoucherType { get; set; }
    }
}
