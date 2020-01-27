namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resulsheet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultSheets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Studentid = c.String(),
                        Subjectid = c.String(),
                        SectionID = c.Int(nullable: false),
                        SessionsID = c.Int(nullable: false),
                        classesID = c.Int(nullable: false),
                        TermsID = c.Int(nullable: false),
                        AssignmentMakrs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MidMarks = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalTerm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddDetails = c.DateTime(nullable: false),
                        Deletedetails = c.DateTime(nullable: false),
                        Updatedetails = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResultSheets");
        }
    }
}
