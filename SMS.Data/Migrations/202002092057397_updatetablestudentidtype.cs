namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablestudentidtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResultSheets", "Studentid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResultSheets", "Studentid", c => c.String());
        }
    }
}
