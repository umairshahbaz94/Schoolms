using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class statustbl
    {
        [Key]
        public int ID { get; set; }
       
        public string name { get; set; }
    }
}
