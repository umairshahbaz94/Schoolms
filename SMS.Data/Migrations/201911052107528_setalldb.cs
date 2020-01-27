namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setalldb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues1", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues1", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues1", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues2", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues2", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues2", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues3", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues3", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues3", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues4", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues4", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues4", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues5", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues5", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues5", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues6", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues6", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues6", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues7", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues7", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues7", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues8", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues8", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues8", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues9", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues9", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues9", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues9", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues9", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues9", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues8", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues8", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues8", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues7", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues7", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues7", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues6", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues6", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues6", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues5", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues5", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues5", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues4", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues4", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues4", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues3", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues3", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues3", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Totaldues1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Cdues1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.allSemesterfeesRecords", "Pudues1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
