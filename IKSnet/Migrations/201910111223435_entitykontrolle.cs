namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitykontrolle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kontrolle", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Kontrolle", new[] { "UserID" });
            AddColumn("dbo.Kontrolle", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Kontrolle", "UserID", c => c.String());
            CreateIndex("dbo.Kontrolle", "ApplicationUser_Id");
            AddForeignKey("dbo.Kontrolle", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kontrolle", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Kontrolle", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Kontrolle", "UserID", c => c.String(maxLength: 128));
            DropColumn("dbo.Kontrolle", "ApplicationUser_Id");
            CreateIndex("dbo.Kontrolle", "UserID");
            AddForeignKey("dbo.Kontrolle", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
