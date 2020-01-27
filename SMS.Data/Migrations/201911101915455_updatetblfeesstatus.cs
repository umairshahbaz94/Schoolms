namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetblfeesstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentFeesStatus", "localtotalamount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentFeesStatus", "localtotalamount");
        }
    }
}
