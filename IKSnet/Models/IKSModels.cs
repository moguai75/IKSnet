using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IKSnet.Models
{

    public class Risiko
    {
        [Display(Name = "Risiko")]
        public int ID { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Risikobeschreibung { get; set; }
        public Eintritt Eintrittswahrscheinlichkeit { get; set; }
        public Schaden Schadenausmass { get; set; }
        public int? Bewertung { get; set; }
        public int? ProzessaktivitaetID { get; set; }
        [Display(Name = "Risikokategorie")]
        public int RisikokategorieID { get; set; }
        public virtual Prozessaktivitaet Prozessaktivitaet { get; set; }
        public virtual Risikokategorie Risikokategorie { get; set; }

        public virtual ICollection<Kontrolle> Kontrolles { get; set; }
    }

    public class Risikokategorie
    {
        [Display(Name = "Risikokategorie")]
        public int ID { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
        public virtual ICollection<Risiko> Risikos { get; set; }
    }

    public enum Schaden
    {
        Nicht_bewertet,
        Unbedeutend,
        Gering,
        Spürbar,
        Kritisch,
        Katastrophal
    }


    public enum Eintritt
    {
        Nicht_bewertet,
        Unwahrscheinlich,
        Sehr_selten,
        Selten,
        Möglich,
        Häufig
    }
    public enum KontrollArt
    {
        Manuell,
        Halbautomatisch,
        Automatisch
    }
    public enum KontrollStatus
    {
        Erfasst,
        Aktiv,
        Inaktiv
    }
    public enum KontrollFrequenz
    {
        Laufend,
        Täglich,
        Wöchentlich,
        Monatlich,
        Quartalsweise,
        Halbjährlich,
        Jährlich
    }
    public enum AufgabeStatus
    {
        Erfasst,
        Pendent,
        Abgeschlossen
    }

    public class Kontrolle
    {

        [Display(Name = "Kontrolle")]
        public int ID { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Beschreibung { get; set; }
        [Display(Name = "Verantwortlich")]
        [Required]
        public string ApplicationUserID { get; set; }
        [Display(Name = "Organisationseinheit")]
        public int OrganisationseinheitID { get; set; }
        [Display(Name = "Risiko")]
        public int? RisikoID { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Ende { get; set; }
        [Display(Name = "Kontrollfrequenz")]
        public KontrollFrequenz KontrollFrequenz { get; set; }
        [Display(Name = "Kontrollart")]
        public KontrollArt KontrollArt { get; set; }
        public KontrollStatus Status { get; set; }
        public virtual Organisationseinheit Organisationseinheit { get; set; }
        public virtual Risiko Risiko { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Aufgabe> Aufgabes { get; set; }
    }

    public class Organisationseinheit
    {
        [Display(Name = "Organisationseinheit")]
        public int ID { get; set; }
        [Required]
        public string Kurzbezeichnung { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
        public virtual ICollection<Kontrolle> Kontrolles { get; set; }

    }

    public class Prozess
    {
        [Display(Name = "Prozess")]
        public int ID { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Beschreibung { get; set; }
        [Display(Name = "Prozesskategorie")]
        public int ProzesskategorieID { get; set; }
        public virtual Prozesskategorie Prozesskategorie { get; set; }
        public virtual ICollection<Prozessaktivitaet> Prozessaktivitaets { get; set; }

    }

    public class Prozesskategorie
    {
        [Display(Name = "Prozesskategorie")]
        public int ID { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
        public virtual ICollection<Prozess> Prozesss { get; set; }
    }


    public class Prozessaktivitaet
    {
        [Display(Name = "Prozessaktivität")]
        public int ID { get; set; }
        [Required]
        public int Sortierung { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Beschreibung { get; set; }
        public int ProzessID { get; set; }
        public virtual Prozess Prozess { get; set; }
        public virtual ICollection<Risiko> Risikos { get; set; }

    }


    public class Aufgabe
    {
        [Display(Name = "Aufgabe")]
        public int ID { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Beschreibung { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fällig am")]
        public DateTime Faellig { get; set; }
        public AufgabeStatus Status { get; set; }
        [Display(Name = "Zugeordnete Kontrolle")]
        public int KontrolleID { get; set; }
        [Display(Name = "Verantwortlich")]
        [Required]
        public string ApplicationUserID { get; set; }
        public string Kommentar { get; set; }
        public string Visum { get; set; }
        public string Dokument { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Erledigt am")]
        public DateTime? Erledigt { get; set; }

        public virtual Kontrolle Kontrolle { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }

    public class Dokument
    {
        [Display(Name = "Dokument")]
        public int ID { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Beschreibung { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Gültig ab")]
        public DateTime GueltigAb { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Gültig bis")]
        public DateTime? GueltigBis { get; set; }
        public string Dateiname { get; set; }    

    }

}