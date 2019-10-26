namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dokumentstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dokument", "Titel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dokument", "Titel", c => c.Int(nullable: false));
        }
    }
}
