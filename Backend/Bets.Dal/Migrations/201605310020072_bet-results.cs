namespace Bets.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class betresults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BetResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Soceed = c.Boolean(),
                        Comment = c.String(),
                        Gain = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MakeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bets", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Bets", "Result_Id", c => c.Int());
            CreateIndex("dbo.Bets", "Result_Id");
            AddForeignKey("dbo.Bets", "Result_Id", "dbo.BetResults", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "Result_Id", "dbo.BetResults");
            DropIndex("dbo.Bets", new[] { "Result_Id" });
            DropColumn("dbo.Bets", "Result_Id");
            DropColumn("dbo.Bets", "Amount");
            DropTable("dbo.BetResults");
        }
    }
}
