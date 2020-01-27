namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateallsemester : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.allSemesterfeesRecords", "session", c => c.Int(nullable: false));
            AddColumn("dbo.allSemesterfeesRecords", "classes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.allSemesterfeesRecords", "classes");
            DropColumn("dbo.allSemesterfeesRecords", "session");
        }
    }
}
