namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alldbcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.allpics",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        url = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AuthorityDetailTbls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        branchname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Challanfees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        AdmissionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TutionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LibraryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankID = c.String(),
                        LaboratoryCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiscellaneousCharges1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiscellaneousCharges2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiscellaneousCharges3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiscellaneousCharge4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        classname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.classesStudentMappings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentID = c.String(),
                        SectionID = c.Int(nullable: false),
                        SessionID = c.Int(nullable: false),
                        TermID = c.Int(nullable: false),
                        classesID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                        des = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DiscountAdvancetbls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        referenceno = c.String(),
                        ReferenceDate = c.DateTime(nullable: false),
                        VouchertypeID = c.Int(nullable: false),
                        authid = c.Int(nullable: false),
                        Refimge = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discounttbls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DisID = c.Int(nullable: false),
                        Stdid = c.Int(nullable: false),
                        tmId = c.Int(nullable: false),
                        headcode = c.Int(nullable: false),
                        vocid = c.Int(nullable: false),
                        discountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubHead3Code_SubHeadCode3 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubHead3Code", t => t.SubHead3Code_SubHeadCode3)
                .Index(t => t.SubHead3Code_SubHeadCode3);
            
            CreateTable(
                "dbo.SubHead3Code",
                c => new
                    {
                        SubHeadCode3 = c.Int(nullable: false, identity: true),
                        SubHead2Code = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubHeadCode3);
            
            CreateTable(
                "dbo.FeeScheduleStructures",
                c => new
                    {
                        FeeStrID = c.Int(nullable: false, identity: true),
                        FeeVoucherTypeCode = c.Int(nullable: false),
                        FVBranchCode = c.Int(nullable: false),
                        FVClassCode = c.Int(nullable: false),
                        ProgramdegreeId = c.Int(nullable: false),
                        FVSessionCode = c.Int(nullable: false),
                        FVCategoryCode = c.Int(nullable: false),
                        FVSectionCode = c.Int(nullable: false),
                        FVTermCode = c.Int(nullable: false),
                        FVDueDate = c.String(),
                        FVFineLumsumValue = c.String(),
                        FVFinePerDay = c.String(),
                        FVAlertDays = c.String(),
                        FVAccountno = c.String(),
                        FVAccountTitle = c.String(),
                        FVdiscription = c.String(),
                    })
                .PrimaryKey(t => t.FeeStrID);
            
            CreateTable(
                "dbo.FeeVoucherHeadDetails",
                c => new
                    {
                        FeeStrID = c.Int(nullable: false, identity: true),
                        fk_strif = c.Int(nullable: false),
                        SubHead3Code = c.Int(nullable: false),
                        HeadValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThirdVPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FeeStrID);
            
            CreateTable(
                "dbo.FeeVoucherTypes",
                c => new
                    {
                        FeeVoucherTypeCode = c.Int(nullable: false, identity: true),
                        feeVoucherType = c.String(),
                    })
                .PrimaryKey(t => t.FeeVoucherTypeCode);
            
            CreateTable(
                "dbo.MHeadCodes",
                c => new
                    {
                        MainHeadCode = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MainHeadCode);
            
            CreateTable(
                "dbo.Programdegrees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Pname = c.String(),
                        ProgramAddDate = c.DateTime(),
                        ProgramUpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sectionName = c.String(),
                        sectionDescription = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sessionname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.setVoucherpercents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Studentcode = c.Int(nullable: false),
                        v1 = c.Int(nullable: false),
                        V1Account = c.String(),
                        v2 = c.Int(nullable: false),
                        V2Account = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Smslogoes",
                c => new
                    {
                        logoid = c.Int(nullable: false, identity: true),
                        imagepath = c.String(),
                    })
                .PrimaryKey(t => t.logoid);
            
            CreateTable(
                "dbo.statustbls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentBranchMappings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentID = c.String(),
                        BranchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.StudentCurrentStatus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        BranchID = c.String(),
                        SectionID = c.Int(nullable: false),
                        classesID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        SessionID = c.Int(nullable: false),
                        TermID = c.Int(nullable: false),
                        ProgramdegreeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.classes", t => t.classesID, cascadeDelete: true)
                .ForeignKey("dbo.Programdegrees", t => t.ProgramdegreeID, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Terms", t => t.TermID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.SectionID)
                .Index(t => t.classesID)
                .Index(t => t.CategoryID)
                .Index(t => t.SessionID)
                .Index(t => t.TermID)
                .Index(t => t.ProgramdegreeID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RollNo = c.String(),
                        Name = c.String(),
                        FatherName = c.String(),
                        whatsappNumber = c.String(),
                        AdmissionFormNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        Dateofbirth = c.DateTime(),
                        AdmissionDate = c.DateTime(),
                        Admissionimage = c.String(),
                        Number = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TermName = c.String(),
                        TermDescription = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.StudentFeesStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        classID = c.Int(nullable: false),
                        Section = c.Int(nullable: false),
                        term = c.Int(nullable: false),
                        session = c.Int(nullable: false),
                        VoucherType = c.Int(nullable: false),
                        totalAmtsharedv = c.Int(nullable: false),
                        Accountnosharedv = c.String(),
                        VoucherNO = c.String(),
                        VoucherNOS = c.String(),
                        RecevieAmount = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        statusReview = c.String(),
                        SStatusReview = c.String(),
                        SStatus = c.Int(nullable: false),
                        DueDate = c.DateTime(),
                        DueDatev = c.DateTime(),
                        localvochardiscount = c.Decimal(precision: 18, scale: 2),
                        Svochardiscount = c.Decimal(precision: 18, scale: 2),
                        pid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubHead1Code",
                c => new
                    {
                        SubHeadCode1 = c.Int(nullable: false, identity: true),
                        MainHeadCode = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubHeadCode1);
            
            CreateTable(
                "dbo.SubHead2Code",
                c => new
                    {
                        SubHeadCode2 = c.Int(nullable: false, identity: true),
                        SubHead1Code = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubHeadCode2);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VoucherAccountv1andV2",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        VocherName = c.String(),
                        Accountnumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentCurrentStatus", "TermID", "dbo.Terms");
            DropForeignKey("dbo.StudentCurrentStatus", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentCurrentStatus", "SessionID", "dbo.Sessions");
            DropForeignKey("dbo.StudentCurrentStatus", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.StudentCurrentStatus", "ProgramdegreeID", "dbo.Programdegrees");
            DropForeignKey("dbo.StudentCurrentStatus", "classesID", "dbo.classes");
            DropForeignKey("dbo.StudentCurrentStatus", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Discounttbls", "SubHead3Code_SubHeadCode3", "dbo.SubHead3Code");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StudentCurrentStatus", new[] { "ProgramdegreeID" });
            DropIndex("dbo.StudentCurrentStatus", new[] { "TermID" });
            DropIndex("dbo.StudentCurrentStatus", new[] { "SessionID" });
            DropIndex("dbo.StudentCurrentStatus", new[] { "CategoryID" });
            DropIndex("dbo.StudentCurrentStatus", new[] { "classesID" });
            DropIndex("dbo.StudentCurrentStatus", new[] { "SectionID" });
            DropIndex("dbo.StudentCurrentStatus", new[] { "StudentID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Discounttbls", new[] { "SubHead3Code_SubHeadCode3" });
            DropTable("dbo.VoucherAccountv1andV2");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SubHead2Code");
            DropTable("dbo.SubHead1Code");
            DropTable("dbo.StudentFeesStatus");
            DropTable("dbo.Terms");
            DropTable("dbo.Students");
            DropTable("dbo.StudentCurrentStatus");
            DropTable("dbo.StudentBranchMappings");
            DropTable("dbo.statustbls");
            DropTable("dbo.Smslogoes");
            DropTable("dbo.setVoucherpercents");
            DropTable("dbo.Sessions");
            DropTable("dbo.Sections");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Programdegrees");
            DropTable("dbo.MHeadCodes");
            DropTable("dbo.FeeVoucherTypes");
            DropTable("dbo.FeeVoucherHeadDetails");
            DropTable("dbo.FeeScheduleStructures");
            DropTable("dbo.SubHead3Code");
            DropTable("dbo.Discounttbls");
            DropTable("dbo.DiscountAdvancetbls");
            DropTable("dbo.classesStudentMappings");
            DropTable("dbo.classes");
            DropTable("dbo.Challanfees");
            DropTable("dbo.Categories");
            DropTable("dbo.Branches");
            DropTable("dbo.Banks");
            DropTable("dbo.AuthorityDetailTbls");
            DropTable("dbo.allpics");
        }
    }
}
