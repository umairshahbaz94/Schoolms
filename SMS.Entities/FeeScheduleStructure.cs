using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public  class FeeScheduleStructure
    {

        [Key]

        public int FeeStrID { get; set; }
        public int FeeVoucherTypeCode { get; set; }
        public int FVBranchCode { get; set; }
        public int FVClassCode { get; set; }
        public int ProgramdegreeId { get; set; }
        public int FVSessionCode { get; set; }
        public int FVCategoryCode { get; set; }
        public int FVSectionCode { get; set; }
        public int FVTermCode{ get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy }", ApplyFormatInEditMode = true)]
        public string FVDueDate { get; set; }
        public string FVFineLumsumValue { get; set; }
        public string FVFinePerDay { get; set; }
        public string FVAlertDays { get; set; }
        public string FVAccountno { get; set; }
        public string FVAccountTitle { get; set; }
        public string FVdiscription { get; set; }

    }
}
