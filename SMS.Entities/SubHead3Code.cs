using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
 public   class SubHead3Code
    {
        [Key]
        public int SubHeadCode3 { get; set; }
      
        public int SubHead2Code { get; set; }
   public string   Description { get; set; }
 
    }
}
