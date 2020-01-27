using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class SubHead2Code
    {
        [Key]
        public int SubHeadCode2 { get; set; }
        
        public int SubHead1Code { get; set; }
        public string Description { get; set; }
    }
}
