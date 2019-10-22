namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fremdschluessel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Kontrolle", new[] { "Risiko_ID" });
            DropIndex("dbo.Risiko", new[] { "Prozessaktivitaet_ID" });
            DropIndex("dbo.Prozessaktivitaet", new[] { "Prozess_ID" });
            RenameColumn(table: "dbo.Kontrolle", name: "Risiko_ID", newName: "RisikoID");
            RenameColumn(table: "dbo.Risiko", name: "Prozessaktivitaet_ID", newName: "ProzessaktivitaetID");
            RenameColumn(table: "dbo.Prozessaktivitaet", name: "Prozess_ID", newName: "ProzessID");
            AlterColumn("dbo.Kontrolle", "RisikoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Risiko", "ProzessaktivitaetID", c => c.Int(nullable: false));
            AlterColumn("dbo.Prozessaktivitaet", "ProzessID", c => c.Int(nullable: false));
            CreateIndex("dbo.Kontrolle", "RisikoID");
            CreateIndex("dbo.Risiko", "ProzessaktivitaetID");
            CreateIndex("dbo.Prozessaktivitaet", "ProzessID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Prozessaktivitaet", new[] { "ProzessID" });
            DropIndex("dbo.Risiko", new[] { "ProzessaktivitaetID" });
            DropIndex("dbo.Kontrolle", new[] { "RisikoID" });
            AlterColumn("dbo.Prozessaktivitaet", "ProzessID", c => c.Int());
            AlterColumn("dbo.Risiko", "ProzessaktivitaetID", c => c.Int());
            AlterColumn("dbo.Kontrolle", "RisikoID", c => c.Int());
            RenameColumn(table: "dbo.Prozessaktivitaet", name: "ProzessID", newName: "Prozess_ID");
            RenameColumn(table: "dbo.Risiko", name: "ProzessaktivitaetID", newName: "Prozessaktivitaet_ID");
            RenameColumn(table: "dbo.Kontrolle", name: "RisikoID", newName: "Risiko_ID");
            CreateIndex("dbo.Prozessaktivitaet", "Prozess_ID");
            CreateIndex("dbo.Risiko", "Prozessaktivitaet_ID");
            CreateIndex("dbo.Kontrolle", "Risiko_ID");
        }
    }
}
