namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dokumentgueltigbis : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dokument", "GueltigBis", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dokument", "GueltigBis", c => c.DateTime(nullable: false));
        }
    }
}
