namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saveallSemesterfeesRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.allSemesterfeesRecords",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                        Pudues1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pudues2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pudues3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pudues4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pudues5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pudues6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pudues7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pudues8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pudues9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cdues9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totaldues9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.allSemesterfeesRecords");
        }
    }
}
