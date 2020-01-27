using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class SubHead1Code
    {
        [Key]
        public int SubHeadCode1 { get; set; }
        public int MainHeadCode { get; set; }
        public string Description { get; set; }

    }
}
