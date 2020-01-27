namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class okalldbs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentFeesStatus", "totalAmtsharedv", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentFeesStatus", "totalAmtsharedv", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
