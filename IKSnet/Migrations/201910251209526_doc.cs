namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dokument", "Dateiname", c => c.String());
            DropColumn("dbo.Dokument", "Link");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dokument", "Link", c => c.String());
            DropColumn("dbo.Dokument", "Dateiname");
        }
    }
}
