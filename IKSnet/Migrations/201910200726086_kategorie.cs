namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategorie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prozessaktivitaet", "Beschreibung", c => c.String(nullable: false));
            AlterColumn("dbo.Prozess", "Beschreibung", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prozess", "Beschreibung", c => c.String());
            AlterColumn("dbo.Prozessaktivitaet", "Beschreibung", c => c.String());
        }
    }
}
