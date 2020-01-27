using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
  public  class FeeVoucherHeadDetail
    {
        [Key]

        [Column("FeeStrID")]
        public int Id { get; set; }
        [DisplayName("className")]
        public int fk_strif { get; set; }
        public int SubHead3Code { get; set; }
        [NotMapped]
        public virtual SubHead3Code SubHead3Codes { get; set; }
        public decimal HeadValue { get; set; }
        public decimal ThirdVPercent { get; set; }
    }
}
