namespace Bets.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Game = c.String(),
                        Tournament = c.String(),
                        Forecast = c.String(),
                        Content = c.String(),
                        Coefficient = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GameStartDate = c.DateTime(nullable: false),
                        ShowDate = c.DateTime(nullable: false),
                        MakeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SimpleCustomerAccounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(maxLength: 255),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.UserName, unique: true, name: "IX_Unique")
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SimpleCustomerAccounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.SimpleCustomerAccounts");
            DropForeignKey("dbo.SimpleCustomerAccounts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.SimpleCustomerAccounts", new[] { "Customer_Id" });
            DropIndex("dbo.SimpleCustomerAccounts", "IX_Unique");
            DropTable("dbo.UserRoles");
            DropTable("dbo.SimpleCustomerAccounts");
            DropTable("dbo.Customers");
            DropTable("dbo.Bets");
        }
    }
}
