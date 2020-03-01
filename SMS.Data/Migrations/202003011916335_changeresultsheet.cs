namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeresultsheet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResultSheets", "Grade", c => c.String());
            AddColumn("dbo.ResultSheets", "Point", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResultSheets", "Point");
            DropColumn("dbo.ResultSheets", "Grade");
        }
    }
}
