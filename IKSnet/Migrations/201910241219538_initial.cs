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
                        Titel = c.String(nullable: false),
                        Beschreibung = c.String(nullable: false),
                        Faellig = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        KontrolleID = c.Int(nullable: false),
                        ApplicationUserID = c.String(nullable: false, maxLength: 128),
                        Kommentar = c.String(),
                        Visum = c.String(),
                        Dokument = c.String(),
                        Erledigt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Kontrolle", t => t.KontrolleID)
                .Index(t => t.KontrolleID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.Int(nullable: false),
                        BenutzerName = c.String(),
                        Name = c.String(),
                        Vorname = c.String(),
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
                "dbo.Kontrolle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.String(nullable: false),
                        Beschreibung = c.String(nullable: false),
                        ApplicationUserID = c.String(nullable: false, maxLength: 128),
                        OrganisationseinheitID = c.Int(nullable: false),
                        RisikoID = c.Int(),
                        Start = c.DateTime(nullable: false),
                        Ende = c.DateTime(),
                        KontrollFrequenz = c.Int(nullable: false),
                        KontrollArt = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Organisationseinheit", t => t.OrganisationseinheitID)
                .ForeignKey("dbo.Risiko", t => t.RisikoID)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.OrganisationseinheitID)
                .Index(t => t.RisikoID);
            
            CreateTable(
                "dbo.Organisationseinheit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Kurzbezeichnung = c.String(nullable: false),
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
                        Bewertung = c.Int(),
                        ProzessaktivitaetID = c.Int(),
                        RisikokategorieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prozessaktivitaet", t => t.ProzessaktivitaetID)
                .ForeignKey("dbo.Risikokategorie", t => t.RisikokategorieID)
                .Index(t => t.ProzessaktivitaetID)
                .Index(t => t.RisikokategorieID);
            
            CreateTable(
                "dbo.Prozessaktivitaet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sortierung = c.Int(nullable: false),
                        Titel = c.String(nullable: false),
                        Beschreibung = c.String(nullable: false),
                        ProzessID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prozess", t => t.ProzessID)
                .Index(t => t.ProzessID);
            
            CreateTable(
                "dbo.Prozess",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.String(nullable: false),
                        Beschreibung = c.String(nullable: false),
                        ProzesskategorieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prozesskategorie", t => t.ProzesskategorieID)
                .Index(t => t.ProzesskategorieID);
            
            CreateTable(
                "dbo.Prozesskategorie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Risikokategorie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.Dokument",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titel = c.Int(nullable: false),
                        Beschreibung = c.String(nullable: false),
                        GueltigAb = c.DateTime(nullable: false),
                        GueltigBis = c.DateTime(nullable: false),
                        Link = c.String(),
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Risiko", "RisikokategorieID", "dbo.Risikokategorie");
            DropForeignKey("dbo.Risiko", "ProzessaktivitaetID", "dbo.Prozessaktivitaet");
            DropForeignKey("dbo.Prozess", "ProzesskategorieID", "dbo.Prozesskategorie");
            DropForeignKey("dbo.Prozessaktivitaet", "ProzessID", "dbo.Prozess");
            DropForeignKey("dbo.Kontrolle", "RisikoID", "dbo.Risiko");
            DropForeignKey("dbo.Kontrolle", "OrganisationseinheitID", "dbo.Organisationseinheit");
            DropForeignKey("dbo.Aufgabe", "KontrolleID", "dbo.Kontrolle");
            DropForeignKey("dbo.Kontrolle", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Aufgabe", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Prozess", new[] { "ProzesskategorieID" });
            DropIndex("dbo.Prozessaktivitaet", new[] { "ProzessID" });
            DropIndex("dbo.Risiko", new[] { "RisikokategorieID" });
            DropIndex("dbo.Risiko", new[] { "ProzessaktivitaetID" });
            DropIndex("dbo.Kontrolle", new[] { "RisikoID" });
            DropIndex("dbo.Kontrolle", new[] { "OrganisationseinheitID" });
            DropIndex("dbo.Kontrolle", new[] { "ApplicationUserID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Aufgabe", new[] { "ApplicationUserID" });
            DropIndex("dbo.Aufgabe", new[] { "KontrolleID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Dokument");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Risikokategorie");
            DropTable("dbo.Prozesskategorie");
            DropTable("dbo.Prozess");
            DropTable("dbo.Prozessaktivitaet");
            DropTable("dbo.Risiko");
            DropTable("dbo.Organisationseinheit");
            DropTable("dbo.Kontrolle");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Aufgabe");
        }
    }
}
