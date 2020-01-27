namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fineheadadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.fineHeads",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        HeadValue = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Discounttbls", "statusfine", c => c.Int(nullable: false));
            AddColumn("dbo.Discounttbls", "vstatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discounttbls", "vstatus");
            DropColumn("dbo.Discounttbls", "statusfine");
            DropTable("dbo.fineHeads");
        }
    }
}
