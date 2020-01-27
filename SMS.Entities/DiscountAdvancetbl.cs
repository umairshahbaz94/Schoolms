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
    public class DiscountAdvancetbl
    {

        public int Id { get; set; }
        public int StudentID { get; set; }
        public string referenceno { get; set; }
        public DateTime ReferenceDate { get; set; }
        public int VouchertypeID { get; set; }
        public int authid { get; set; }
        public string Refimge { get; set; }
        //[NotMapped]
        //public HttpPostedFileBase imagefile { get; set; }
    }
}
