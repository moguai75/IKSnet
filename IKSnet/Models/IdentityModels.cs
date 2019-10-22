using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IKSnet.Models
{
    public enum Status { Erfasst, Aktiviert, Deaktiviert }
    // Sie können Profildaten für den Benutzer hinzufügen, indem Sie der ApplicationUser-Klasse weitere Eigenschaften hinzufügen. Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Beachten Sie, dass der "authenticationType" mit dem in "CookieAuthenticationOptions.AuthenticationType" definierten Typ übereinstimmen muss.
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Benutzerdefinierte Benutzeransprüche hier hinzufügen
            return userIdentity;
        }
        public Status Status { get; set; }

        [Display(Name = "Verantwortlich")]
        public string BenutzerName { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Vorname")]

        public string Vorname { get; set; }

        public virtual ICollection<Kontrolle> Kontrolles { get; set; }

        public virtual ICollection<Aufgabe> Aufgabes { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IKSnetDB", throwIfV1Schema: false)
        {
        }

        public DbSet<Organisationseinheit> Organisationseinheits { get; set; }
        public DbSet<Kontrolle> Kontrolles { get; set; }
        public DbSet<Risiko> Risikos { get; set; }
        public DbSet<Prozess> Prozesss { get; set; }
        public DbSet<Prozessaktivitaet> Prozessaktivitaets { get; set; }
        public DbSet<Prozesskategorie> Prozesskategories { get; set; }
        public DbSet<Risikokategorie> Risikokategories { get; set; }
        public DbSet<Aufgabe> Aufgabes { get; set; }
        public DbSet<Dokument> Dokuments { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}