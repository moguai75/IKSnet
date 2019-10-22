namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class benutzer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BenutzerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BenutzerName");
        }
    }
}
