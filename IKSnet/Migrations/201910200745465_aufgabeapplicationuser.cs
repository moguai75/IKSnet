namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aufgabeapplicationuser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Aufgabe", name: "ApplicationUser_Id", newName: "ApplicationUserID");
            RenameIndex(table: "dbo.Aufgabe", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserID");
            DropColumn("dbo.Aufgabe", "ApplicationsUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aufgabe", "ApplicationsUserID", c => c.String());
            RenameIndex(table: "dbo.Aufgabe", name: "IX_ApplicationUserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Aufgabe", name: "ApplicationUserID", newName: "ApplicationUser_Id");
        }
    }
}
