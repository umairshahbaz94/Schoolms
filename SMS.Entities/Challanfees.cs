using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entities
{
   public class Challanfees
    {
        public int ID { get; set; }
        public string StudentID { get; set; }
        public DateTime DueDate  { get; set; }
        public decimal AdmissionFee { get; set; }
        public decimal TutionFee { get; set; }
        public decimal LibraryFee { get; set; }
        public string BankID { get; set; }
        public decimal LaboratoryCharges { get; set; }
        public decimal MiscellaneousCharges1  { get; set; }
        public decimal MiscellaneousCharges2 { get; set; }
        public decimal MiscellaneousCharges3 { get; set; }
        public decimal MiscellaneousCharge4 { get; set; }


    }
}
