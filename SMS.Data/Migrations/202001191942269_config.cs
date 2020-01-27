namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class config : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.configfiles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        grade = c.String(),
                        Point = c.Decimal(nullable: false, precision: 18, scale: 2),
                        highvalue = c.Int(nullable: false),
                        lowvalue = c.Int(nullable: false),
                        Updatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.configfiles");
        }
    }
}
