namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class savecourseclassmappinganteachercourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.courseclassmappings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Subjectsid = c.Int(nullable: false),
                        classesId = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.teachersubjectCourses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        courseclassmappingid = c.Int(nullable: false),
                        teacherID = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Teachers", "Addteacherdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Teachers", "Addteacher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Addteacher", c => c.DateTime(nullable: false));
            DropColumn("dbo.Teachers", "Addteacherdate");
            DropTable("dbo.teachersubjectCourses");
            DropTable("dbo.courseclassmappings");
        }
    }
}
