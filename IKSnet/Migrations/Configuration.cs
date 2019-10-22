namespace IKSnet.Migrations
{
    using IKSnet.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IKSnet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IKSnet.Models.ApplicationDbContext context)
        {
            context.Organisationseinheits.AddOrUpdate(i => i.Kurzbezeichnung,
                new Organisationseinheit { Kurzbezeichnung = "FA", Bezeichnung = "Familienzulagen" },
                new Organisationseinheit { Kurzbezeichnung = "FB", Bezeichnung = "Finanzbuchhaltung" });

            context.SaveChanges();

            context.Risikokategories.AddOrUpdate(i => i.Bezeichnung,
                new Risikokategorie { Bezeichnung = "Finanz Risiken" },
                new Risikokategorie { Bezeichnung = "Prozess Risiken" });

            context.SaveChanges();



            context.Prozesskategories.AddOrUpdate(i => i.Bezeichnung,
                new Prozesskategorie { Bezeichnung = "F�hrungsprozesse" },
                new Prozesskategorie { Bezeichnung = "Unterst�tzungsprozesse" });

            context.SaveChanges();


            context.Prozesss.AddOrUpdate(i => i.Titel,
                new Prozess { Titel = "Jahresabschluss", Beschreibung = "Erzeugen und �bermitteln einer XML-Datei, welche den Jahresabschluss (FIBU) enth�lt", ProzesskategorieID = 1 },
                new Prozess { Titel = "IK Jahresmeldung (Teilmeldung)", Beschreibung = "Erzeugen und �bermitteln einer XML-Datei, welche die neu erfassten und gepr�ften IK-Eintragungen enth�lt", ProzesskategorieID = 2 });

            context.SaveChanges();

            context.Prozessaktivitaets.AddOrUpdate(i => i.Sortierung,
                new Prozessaktivitaet { Sortierung = 1, Titel = "IK-Jahresmeldung aufbereiten", Beschreibung = "Stellt die neuen und erfolgreich gepr�ften IK-Buchungen in den Tabellen ZIK/ZID f�r die Meldung an die ZAS bereit", ProzessID = 1 },
                new Prozessaktivitaet { Sortierung = 2, Titel = "IK-Jahresmeldungdatei erzeugen", Beschreibung = "Aufbereitung der Daten", ProzessID = 1 },
                new Prozessaktivitaet { Sortierung = 3, Titel = "IK-Jahresmeldung �bermitteln", Beschreibung = "�bermittlung der Daten (XML) an die ZAS", ProzessID = 1 },
                new Prozessaktivitaet { Sortierung = 1, Titel = "ZAS Meldung aufbereiten", Beschreibung = "Stellt die neuen und erfolgreich gepr�ften Daten f�r die Meldung an die ZAS bereit", ProzessID = 2 },
                new Prozessaktivitaet { Sortierung = 2, Titel = "ZAS Datei erstellen", Beschreibung = "Erstellt die ZAS Datei", ProzessID = 2 },
                new Prozessaktivitaet { Sortierung = 3, Titel = "ZAS Datei �bermitteln", Beschreibung = "Kopiert die vorg�ngig erstellte XML-Datei per ftp zur ZAS", ProzessID = 2 });

            context.SaveChanges();

        }
    }
}
