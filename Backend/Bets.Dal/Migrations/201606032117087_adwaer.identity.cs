namespace Bets.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adwaeridentity : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.SimpleCustomerAccounts", name: "IX_Unique", newName: "IX_Unique_UserName");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SimpleCustomerAccounts", name: "IX_Unique_UserName", newName: "IX_Unique");
        }
    }
}
