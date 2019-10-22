namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datekontrollenull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kontrolle", "Ende", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kontrolle", "Ende", c => c.DateTime(nullable: false));
        }
    }
}
