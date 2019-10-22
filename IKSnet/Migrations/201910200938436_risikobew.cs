namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class risikobew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Risiko", "Bewertung", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Risiko", "Bewertung");
        }
    }
}
