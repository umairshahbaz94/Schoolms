namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class masterstatusfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Masterstudentcurrentstatus",
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
                        date = c.DateTime(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Masterstudentcurrentstatus", "TermID", "dbo.Terms");
            DropForeignKey("dbo.Masterstudentcurrentstatus", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Masterstudentcurrentstatus", "SessionID", "dbo.Sessions");
            DropForeignKey("dbo.Masterstudentcurrentstatus", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.Masterstudentcurrentstatus", "ProgramdegreeID", "dbo.Programdegrees");
            DropForeignKey("dbo.Masterstudentcurrentstatus", "classesID", "dbo.classes");
            DropForeignKey("dbo.Masterstudentcurrentstatus", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Masterstudentcurrentstatus", new[] { "ProgramdegreeID" });
            DropIndex("dbo.Masterstudentcurrentstatus", new[] { "TermID" });
            DropIndex("dbo.Masterstudentcurrentstatus", new[] { "SessionID" });
            DropIndex("dbo.Masterstudentcurrentstatus", new[] { "CategoryID" });
            DropIndex("dbo.Masterstudentcurrentstatus", new[] { "classesID" });
            DropIndex("dbo.Masterstudentcurrentstatus", new[] { "SectionID" });
            DropIndex("dbo.Masterstudentcurrentstatus", new[] { "StudentID" });
            DropTable("dbo.Masterstudentcurrentstatus");
        }
    }
}
