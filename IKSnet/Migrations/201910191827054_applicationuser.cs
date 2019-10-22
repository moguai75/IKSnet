namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Kontrolle", name: "ApplicationUser_Id", newName: "ApplicationUserID");
            RenameIndex(table: "dbo.Kontrolle", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserID");
            AddColumn("dbo.Aufgabe", "ApplicationsUserID", c => c.String());
            DropColumn("dbo.Aufgabe", "Verantwortlich");
            DropColumn("dbo.Kontrolle", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kontrolle", "UserID", c => c.String());
            AddColumn("dbo.Aufgabe", "Verantwortlich", c => c.Int(nullable: false));
            DropColumn("dbo.Aufgabe", "ApplicationsUserID");
            RenameIndex(table: "dbo.Kontrolle", name: "IX_ApplicationUserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Kontrolle", name: "ApplicationUserID", newName: "ApplicationUser_Id");
        }
    }
}
