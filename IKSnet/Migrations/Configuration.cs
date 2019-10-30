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
                new Organisationseinheit { Kurzbezeichnung = "FB", Bezeichnung = "Finanzbuchhaltung" },
                new Organisationseinheit { Kurzbezeichnung = "EO", Bezeichnung = "Erwerbsersatz" },
                new Organisationseinheit { Kurzbezeichnung = "IK", Bezeichnung = "Internes Konto" });

            context.SaveChanges();

            context.Risikokategories.AddOrUpdate(i => i.Bezeichnung,
                new Risikokategorie { Bezeichnung = "Risikokategorie 1" },
                new Risikokategorie { Bezeichnung = "Risikokategorie 2" },
                new Risikokategorie { Bezeichnung = "Risikokategorie 3" },
                new Risikokategorie { Bezeichnung = "Risikokategorie 4" });

            context.SaveChanges();



            context.Prozesskategories.AddOrUpdate(i => i.Bezeichnung,
                new Prozesskategorie { Bezeichnung = "Prozesskategorie 1" },
                new Prozesskategorie { Bezeichnung = "Prozesskategorie 2" },
                new Prozesskategorie { Bezeichnung = "Prozesskategorie 3" },
                new Prozesskategorie { Bezeichnung = "Prozesskategorie 4" });

            context.SaveChanges();


            context.Prozesss.AddOrUpdate(i => i.Titel,
                new Prozess { Titel = "Prozess 1", Beschreibung = "Prozess 1", ProzesskategorieID = 1 },
                new Prozess { Titel = "Prozess 2", Beschreibung = "Prozess 2", ProzesskategorieID = 2 },
                new Prozess { Titel = "Prozess 3", Beschreibung = "Prozess 3", ProzesskategorieID = 3 },
                new Prozess { Titel = "Prozess 4", Beschreibung = "Prozess 4", ProzesskategorieID = 4 });

            context.SaveChanges();

            context.Prozessaktivitaets.AddOrUpdate(i => i.Sortierung,
                new Prozessaktivitaet { Sortierung = 1, Titel = "Prozess 1 Prozessaktivität 1", Beschreibung = "Prozess 1 Prozessaktivität 1", ProzessID = 1 },
                new Prozessaktivitaet { Sortierung = 2, Titel = "Prozess 1 Prozessaktivität 2", Beschreibung = "Prozess 1 Prozessaktivität 2", ProzessID = 1 },
                new Prozessaktivitaet { Sortierung = 3, Titel = "Prozess 1 Prozessaktivität 3", Beschreibung = "Prozess 1 Prozessaktivität 3", ProzessID = 1 },
                new Prozessaktivitaet { Sortierung = 1, Titel = "Prozess 2 Prozessaktivität 1", Beschreibung = "Prozess 2 Prozessaktivität 1", ProzessID = 2 },
                new Prozessaktivitaet { Sortierung = 2, Titel = "Prozess 2 Prozessaktivität 2", Beschreibung = "Prozess 2 Prozessaktivität 2", ProzessID = 2 },
                new Prozessaktivitaet { Sortierung = 3, Titel = "Prozess 2 Prozessaktivität 3", Beschreibung = "Prozess 2 Prozessaktivität 3", ProzessID = 2 },
                new Prozessaktivitaet { Sortierung = 1, Titel = "Prozess 3 Prozessaktivität 1", Beschreibung = "Prozess 3 Prozessaktivität 1", ProzessID = 3 },
                new Prozessaktivitaet { Sortierung = 2, Titel = "Prozess 3 Prozessaktivität 2", Beschreibung = "Prozess 3 Prozessaktivität 2", ProzessID = 3 },
                new Prozessaktivitaet { Sortierung = 3, Titel = "Prozess 3 Prozessaktivität 3", Beschreibung = "Prozess 3 Prozessaktivität 3", ProzessID = 3 },
                new Prozessaktivitaet { Sortierung = 1, Titel = "Prozess 4 Prozessaktivität 1", Beschreibung = "Prozess 4 Prozessaktivität 1", ProzessID = 4 },
                new Prozessaktivitaet { Sortierung = 2, Titel = "Prozess 4 Prozessaktivität 2", Beschreibung = "Prozess 4 Prozessaktivität 2", ProzessID = 4 },
                new Prozessaktivitaet { Sortierung = 3, Titel = "Prozess 4 Prozessaktivität 3", Beschreibung = "Prozess 4 Prozessaktivität 3", ProzessID = 4 });

            context.SaveChanges();


            context.Risikos.AddOrUpdate(i => i.Titel,
                new Risiko { Titel = "Risiko 1", Risikobeschreibung = "Risiko 1", RisikokategorieID = 1, Schadenausmass = Schaden.Kritisch, Eintrittswahrscheinlichkeit = Eintritt.Möglich, ProzessaktivitaetID = 1 },
                new Risiko { Titel = "Risiko 2", Risikobeschreibung = "Risiko 2", RisikokategorieID = 2, Schadenausmass = Schaden.Gering, Eintrittswahrscheinlichkeit = Eintritt.Selten, ProzessaktivitaetID = 5 },
                new Risiko { Titel = "Risiko 3", Risikobeschreibung = "Risiko 3", RisikokategorieID = 3, Schadenausmass = Schaden.Kritisch, Eintrittswahrscheinlichkeit = Eintritt.Sehr_selten, ProzessaktivitaetID = 8 },
                new Risiko { Titel = "Risiko 4", Risikobeschreibung = "Risiko 4", RisikokategorieID = 4, Schadenausmass = Schaden.Spürbar, Eintrittswahrscheinlichkeit = Eintritt.Häufig, ProzessaktivitaetID = 9 });

            context.SaveChanges();

            context.Kontrolles.AddOrUpdate(i => i.Titel,
                new Kontrolle { Titel = "Kontrolle 1", Beschreibung = "Kontrolle 1", KontrollArt = KontrollArt.Manuell, KontrollFrequenz = KontrollFrequenz.Monatlich, Status = KontrollStatus.Aktiv, Start = DateTime.Parse("01.01.2019"), ApplicationUserID = "b44aea84-3ea1-4d86-9d03-d1494d60dc51", OrganisationseinheitID = 1, RisikoID = 1 },
                new Kontrolle { Titel = "Kontrolle 2", Beschreibung = "Kontrolle 2", KontrollArt = KontrollArt.Manuell, KontrollFrequenz = KontrollFrequenz.Halbjährlich, Status = KontrollStatus.Aktiv, Start = DateTime.Parse("01.01.2019"), ApplicationUserID = "b44aea84-3ea1-4d86-9d03-d1494d60dc51", OrganisationseinheitID = 1, RisikoID = 2 },
                new Kontrolle { Titel = "Kontrolle 3", Beschreibung = "Kontrolle 3", KontrollArt = KontrollArt.Manuell, KontrollFrequenz = KontrollFrequenz.Laufend, Status = KontrollStatus.Aktiv, Start = DateTime.Parse("01.01.2019"), ApplicationUserID = "b44aea84-3ea1-4d86-9d03-d1494d60dc51", OrganisationseinheitID = 1, RisikoID = 3 },
                new Kontrolle { Titel = "Kontrolle 4", Beschreibung = "Kontrolle 4", KontrollArt = KontrollArt.Manuell, KontrollFrequenz = KontrollFrequenz.Jährlich, Status = KontrollStatus.Inaktiv, Start = DateTime.Parse("01.01.2019"), Ende = DateTime.Parse("30.09.2019"), ApplicationUserID = "b44aea84-3ea1-4d86-9d03-d1494d60dc51", OrganisationseinheitID = 1, RisikoID = 1 },
                new Kontrolle { Titel = "Kontrolle 5", Beschreibung = "Kontrolle 5", KontrollArt = KontrollArt.Manuell, KontrollFrequenz = KontrollFrequenz.Monatlich, Status = KontrollStatus.Aktiv, Start = DateTime.Parse("01.01.2019"), ApplicationUserID = "b44aea84-3ea1-4d86-9d03-d1494d60dc51", OrganisationseinheitID = 1, RisikoID = 4 });

            context.SaveChanges();


            context.Aufgabes.AddOrUpdate(i => i.Titel,
                new Aufgabe { Titel = "Aufgabe 1", Beschreibung = "Aufgabe 1", Faellig = DateTime.Parse("10.11.2019"),  Status = AufgabeStatus.Pendent, ApplicationUserID = "e591463a-303e-42b6-8551-d94a4a4a688e", KontrolleID = 1 },
                new Aufgabe { Titel = "Aufgabe 2", Beschreibung = "Aufgabe 2", Faellig = DateTime.Parse("30.11.2019"), Status = AufgabeStatus.Pendent, ApplicationUserID = "e591463a-303e-42b6-8551-d94a4a4a688e", KontrolleID = 1 },
                new Aufgabe { Titel = "Aufgabe 3", Beschreibung = "Aufgabe 3", Faellig = DateTime.Parse("04.11.2019"), Status = AufgabeStatus.Pendent, ApplicationUserID = "e591463a-303e-42b6-8551-d94a4a4a688e", KontrolleID = 1 },
                new Aufgabe { Titel = "Aufgabe 4", Beschreibung = "Aufgabe 4", Faellig = DateTime.Parse("28.10.2019"), Status = AufgabeStatus.Pendent, ApplicationUserID = "e591463a-303e-42b6-8551-d94a4a4a688e", KontrolleID = 1 },
                new Aufgabe { Titel = "Aufgabe 5", Beschreibung = "Aufgabe 5", Faellig = DateTime.Parse("25.10.2019"), Status = AufgabeStatus.Abgeschlossen, ApplicationUserID = "e591463a-303e-42b6-8551-d94a4a4a688e", KontrolleID = 1, Kommentar = "Alles i.o.", Visum = "Lr", Dokument = "20191020142627_checkliste.doc", Erledigt = DateTime.Parse("20.10.2019") });


            context.SaveChanges();

            context.Dokuments.AddOrUpdate(i => i.Titel,
                new Dokument { Titel = "Dokument 1", Beschreibung = "Dokument 1", GueltigAb = DateTime.Parse("01.01.2019"), Dateiname = "20190101111111_dokument1.doc"},
                new Dokument { Titel = "Dokument 2", Beschreibung = "Dokument 2", GueltigAb = DateTime.Parse("01.01.2019"), Dateiname = "20190101111111_dokument2.doc" },
                new Dokument { Titel = "Dokument 3", Beschreibung = "Dokument 3", GueltigAb = DateTime.Parse("01.01.2019"), Dateiname = "20190101111111_dokument3.doc" },
                new Dokument { Titel = "Dokument 4", Beschreibung = "Dokument 4", GueltigAb = DateTime.Parse("01.01.2019"), Dateiname = "20190101111111_dokument4.doc" });

            context.SaveChanges();


        }
    }
}
