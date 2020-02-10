namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class savedball : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResultSheets", "Studentid", c => c.String());
            AlterColumn("dbo.ResultSheets", "Programdegreesid", c => c.String());
            AlterColumn("dbo.ResultSheets", "Subjectid", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResultSheets", "Subjectid", c => c.Int(nullable: false));
            AlterColumn("dbo.ResultSheets", "Programdegreesid", c => c.Int(nullable: false));
            AlterColumn("dbo.ResultSheets", "Studentid", c => c.Int(nullable: false));
        }
    }
}
