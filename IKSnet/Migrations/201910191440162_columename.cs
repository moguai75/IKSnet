namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columename : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Aufgabe", "RowVersion");
            DropColumn("dbo.Kontrolle", "RowVersion");
            DropColumn("dbo.Organisationseinheit", "RowVersion");
            DropColumn("dbo.Dokument", "RowVersion");
            DropColumn("dbo.Prozessaktivitaet", "RowVersion");
            DropColumn("dbo.Prozess", "RowVersion");
            DropColumn("dbo.Risiko", "RowVersion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Risiko", "RowVersion", c => c.Binary());
            AddColumn("dbo.Prozess", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Prozessaktivitaet", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Dokument", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Organisationseinheit", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Kontrolle", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Aufgabe", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
