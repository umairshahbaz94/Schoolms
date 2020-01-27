using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class MHeadCode
    {
        [Key]
        public int MainHeadCode { get; set; }
        public string Description { get; set; }

    }
}
