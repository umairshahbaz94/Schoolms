namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResultSheets", "Programdegreesid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResultSheets", "Programdegreesid");
        }
    }
}
