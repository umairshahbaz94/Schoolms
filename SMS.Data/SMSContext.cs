using Microsoft.AspNet.Identity.EntityFramework;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
  public  class SMSContext : IdentityDbContext<DMSuser>
    {
        public object statustblss;

        public SMSContext() : base("name=SMSconnection")
        {
        }
        public static SMSContext Create()
        {
            return new SMSContext();
        }

        public DbSet<Section> Section { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<classes> classes { get; set; }
        public DbSet<Challanfees> Challanfees { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<setVoucherpercent> setVoucherpercent { get; set; }
        public DbSet<Session>Sessions { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentBranchMapping> studentBranchMappings { get; set; }
        public DbSet<classesStudentMapping> ClassesStudentMappings{ get; set; }
        public DbSet<StudentCurrentStatus> StudentCurrentStatuses  { get; set; }
        public DbSet<MHeadCode> MHeadCodes { get; set; }
        public DbSet<SubHead1Code> subHead1Codes  { get; set; }
        public DbSet<SubHead2Code> subHead2Codes { get; set; }
        public DbSet<SubHead3Code> subHead3Codes { get; set; } 

        public DbSet<FeeVoucherHeadDetail> FeeVoucherHeadDetails { get; set; }
        public DbSet<FeeScheduleStructure> feeScheduleStructures { get; set; }
        public DbSet<FeeVoucherType> FeeVoucherTypes { get;set; }
        public DbSet<StudentFeesStatus> StudentFeesStatuses { get; set; }
        public DbSet<statustbl> statustbls { get; set; }
        public DbSet<Smslogo> Smslogo { get;set; }
        public DbSet<AuthorityDetailTbl> authorityDetailTbls { get;set; }
        public DbSet<Discounttbl> discounttbls { get;set; }
        public DbSet<DiscountAdvancetbl> discountAdvancetbls { get; set; }
        public DbSet<allpics> allpics { get; set; }
        public DbSet<Programdegree> Programdegree { get; set; }
        public DbSet<VoucherAccountv1andV2> VoucherAccountv1andV2 { get; set; }
        public DbSet<fineHead> fineHead { get; set; }
        public DbSet<Masterstudentcurrentstatus> masterstudentcurrentstatuses { get; set; }
        public DbSet<allSemesterfeesRecord> allSemesterfeesRecord { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<courseclassmapping> courseclassmapping { get; set; }
        public DbSet<teachersubjectCourse> teachersubjectCourse { get; set; }
            public DbSet<configfile> configfile { get; set; }
        public DbSet<ResultSheet> ResultSheet { get; set; }


    }
  
}
