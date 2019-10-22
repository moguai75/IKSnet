namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prozess1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Prozess", new[] { "Prozesskategorie_ID" });
            RenameColumn(table: "dbo.Prozess", name: "Prozesskategorie_ID", newName: "ProzesskategorieID");
            AlterColumn("dbo.Prozess", "ProzesskategorieID", c => c.Int(nullable: false));
            CreateIndex("dbo.Prozess", "ProzesskategorieID");
            DropColumn("dbo.Prozess", "ProzessaktivitaetID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prozess", "ProzessaktivitaetID", c => c.Int(nullable: false));
            DropIndex("dbo.Prozess", new[] { "ProzesskategorieID" });
            AlterColumn("dbo.Prozess", "ProzesskategorieID", c => c.Int());
            RenameColumn(table: "dbo.Prozess", name: "ProzesskategorieID", newName: "Prozesskategorie_ID");
            CreateIndex("dbo.Prozess", "Prozesskategorie_ID");
        }
    }
}
