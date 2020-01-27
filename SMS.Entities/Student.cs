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
   public class Student
    {
        [Key]
        public int ID { get; set; }
        public string RollNo { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string whatsappNumber { get; set; }
        public string AdmissionFormNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
       
        public string Gender { get; set; } 
        public DateTime? Dateofbirth  { get; set; }
        public DateTime ?AdmissionDate { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd HH:mm   }")]
        public string Admissionimage { get; set; }
        public int Number { get; set; }
        public  string status { get; set; }

        [NotMapped]
        public HttpPostedFileBase imagefile { get; set; }

     
      }
    
}
