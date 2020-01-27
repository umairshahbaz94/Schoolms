using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SMS.Entities
{
 public   class Smslogo
    {
        [Key]
        public int logoid { get; set; }
        public string imagepath { get; set; }

        [NotMapped]
        public HttpPostedFileBase imagefile { get; set; }
    }
}
