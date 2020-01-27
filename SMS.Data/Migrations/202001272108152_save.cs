namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class save : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResultSheets", "AddDetails", c => c.DateTime());
            AlterColumn("dbo.ResultSheets", "Deletedetails", c => c.DateTime());
            AlterColumn("dbo.ResultSheets", "Updatedetails", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResultSheets", "Updatedetails", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ResultSheets", "Deletedetails", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ResultSheets", "AddDetails", c => c.DateTime(nullable: false));
        }
    }
}
