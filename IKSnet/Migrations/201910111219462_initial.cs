namespace IKSnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aufgabe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.Int(nullable: false),
                        Beschreibung = c.String(nullable: false),
                        Faellig = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        KontrollID = c.Int(nullable: false),
                        Verantwortlich = c.Int(nullable: false),
                        Kommentar = c.String(),
                        Dokument = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Kontrolle_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Kontrolle", t => t.Kontrolle_ID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Kontrolle_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Kontrolle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.String(nullable: false),
                        Beschreibung = c.String(nullable: false),
                        UserID = c.String(maxLength: 128),
                        OrganisationseinheitID = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        Ende = c.DateTime(nullable: false),
                        KontrollFrequenz = c.Int(nullable: false),
                        KontrollArt = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Risiko_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organisationseinheit", t => t.OrganisationseinheitID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Risiko", t => t.Risiko_ID)
                .Index(t => t.UserID)
                .Index(t => t.OrganisationseinheitID)
                .Index(t => t.Risiko_ID);
            
            CreateTable(
                "dbo.Organisationseinheit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Kurzbezeichnung = c.String(nullable: false),
                        Bezeichnung = c.String(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dokument",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.Int(nullable: false),
                        Beschreibung = c.String(nullable: false),
                        GueltigAb = c.DateTime(nullable: false),
                        GueltigBis = c.DateTime(nullable: false),
                        Link = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Prozessaktivitaet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sortierung = c.Int(nullable: false),
                        Titel = c.String(nullable: false),
                        Beschreibung = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Prozess_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prozess", t => t.Prozess_ID)
                .Index(t => t.Prozess_ID);
            
            CreateTable(
                "dbo.Prozess",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.String(nullable: false),
                        Beschreibung = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Prozesskategorie_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prozesskategorie", t => t.Prozesskategorie_ID)
                .Index(t => t.Prozesskategorie_ID);
            
            CreateTable(
                "dbo.Prozesskategorie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Risiko",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.String(nullable: false),
                        Risikobeschreibung = c.String(nullable: false),
                        Eintrittswahrscheinlichkeit = c.Int(nullable: false),
                        Schadenausmass = c.Int(nullable: false),
                        RisikokategorieID = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        Prozessaktivitaet_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prozessaktivitaet", t => t.Prozessaktivitaet_ID)
                .ForeignKey("dbo.Risikokategorie", t => t.RisikokategorieID)
                .Index(t => t.RisikokategorieID)
                .Index(t => t.Prozessaktivitaet_ID);
            
            CreateTable(
                "dbo.Risikokategorie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Risiko", "RisikokategorieID", "dbo.Risikokategorie");
            DropForeignKey("dbo.Risiko", "Prozessaktivitaet_ID", "dbo.Prozessaktivitaet");
            DropForeignKey("dbo.Kontrolle", "Risiko_ID", "dbo.Risiko");
            DropForeignKey("dbo.Prozess", "Prozesskategorie_ID", "dbo.Prozesskategorie");
            DropForeignKey("dbo.Prozessaktivitaet", "Prozess_ID", "dbo.Prozess");
            DropForeignKey("dbo.Aufgabe", "Kontrolle_ID", "dbo.Kontrolle");
            DropForeignKey("dbo.Kontrolle", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kontrolle", "OrganisationseinheitID", "dbo.Organisationseinheit");
            DropForeignKey("dbo.Aufgabe", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Risiko", new[] { "Prozessaktivitaet_ID" });
            DropIndex("dbo.Risiko", new[] { "RisikokategorieID" });
            DropIndex("dbo.Prozess", new[] { "Prozesskategorie_ID" });
            DropIndex("dbo.Prozessaktivitaet", new[] { "Prozess_ID" });
            DropIndex("dbo.Kontrolle", new[] { "Risiko_ID" });
            DropIndex("dbo.Kontrolle", new[] { "OrganisationseinheitID" });
            DropIndex("dbo.Kontrolle", new[] { "UserID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Aufgabe", new[] { "Kontrolle_ID" });
            DropIndex("dbo.Aufgabe", new[] { "ApplicationUser_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Risikokategorie");
            DropTable("dbo.Risiko");
            DropTable("dbo.Prozesskategorie");
            DropTable("dbo.Prozess");
            DropTable("dbo.Prozessaktivitaet");
            DropTable("dbo.Dokument");
            DropTable("dbo.Organisationseinheit");
            DropTable("dbo.Kontrolle");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Aufgabe");
        }
    }
}
