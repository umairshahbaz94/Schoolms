using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
 public   class StudentfeesStatusmodel
    {
        [Display(Name = " VNo")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string classname { get; set; }
        public  classes Classes {get; set;}
        [Display(Name = "Remarks")]
        public string SStatusReview { get; set; }
        public string branchname { get; set; }

        //public string statusReview { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }
        public string Sessionname { get; set; }

        [Display(Name = "A/c")]
        public string Accountnosharedv { get; set; }

        [Display(Name = "A/c")]
        public string FVAccountno { get; set; }

        public Session session { get; set; }
        [Display(Name="A/C")]
        public string VoucherNO { get; set; }
        public Section Sections   { get; set; }
        public  int Section { get; set; }
        public string TermName { get; set; }
        public int FeeVoucherTypeCode { get; set; }
        [Display(Name = "Dep-Amount")]
        public decimal ? totalAmtsharedv { get; set; }
        
        public string VoucherNOS { get; set; }
        public Term term { get; set; }
        [Display(Name = "Dep-Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy }", ApplyFormatInEditMode = true)]
        public string DueDate { get; set; }  [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy }", ApplyFormatInEditMode = true)]
        [Display(Name = "Dep-Date")]
       
        public string DueDatev { get; set; } 
        [Display(Name= "Dep-Amount")]
         public decimal ? DepAmount { get; set; }
        public int StudentID { get; set; }
        public string sectionName { get; set; }

        [DisplayName("Status")]
        public string status { get; set; }




    }
}
