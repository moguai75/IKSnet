namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prozess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prozess", "ProzessaktivitaetID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prozess", "ProzessaktivitaetID");
        }
    }
}
