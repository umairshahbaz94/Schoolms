using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
    public class StudentFeesStatus
    {
        [Display(Name = " VNo")]
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int classID { get; set; }
        public int Section { get; set; }
        public int term { get; set; }
        public int session { get; set; }
        public int VoucherType { get; set; }
        [Display(Name = "DepositeAmount")]
        public int totalAmtsharedv {get ;set;}
        [Display(Name = "A/c")]
        public string Accountnosharedv { get; set; }

        public string VoucherNO { get; set; }
        [Display(Name = "VoucherNO")]
        public string VoucherNOS { get; set; }
        public int RecevieAmount { get; set; }

        public int status { get; set; }
        public string statusReview { get; set; }
        [Display(Name ="Remarks")]
        public string SStatusReview { get; set; }
        public int SStatus { get; set; }
        [Display(Name = "DepositeDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ? DueDate { get; set; }
        [Display(Name = "DepositeDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        
        public DateTime ? DueDatev { get; set; }
        public decimal? localvochardiscount { get; set; }
        public decimal? Svochardiscount { get; set; }

        public int pid{ get; set; }
        public decimal localtotalamount { get; set; }

    }
}
