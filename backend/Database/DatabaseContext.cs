using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

public class DbContext : IdentityDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder b) =>
    b.UseSqlite("Data Source=database.db");

    public DbSet<Bedrijf> Bedrijven { get; set; }
    public DbSet<Bericht> Berichten { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Ervaringsdeskundige> Ervaringsdeskundigen { get; set; }
    public DbSet<Gebruiker> Gebruikers { get; set; }
    public DbSet<GebruikerRol> GebruikerRollen { get; set; }
    public DbSet<Onderzoek> Onderzoeken { get; set; }
    public DbSet<Rol> Rollen { get; set; }
    public DbSet<Verzorger> Verzorgers { get; set; }
    public DbSet<Beschikbaarheid> Beschikbaarheden {get; set;}
    public DbSet<ErvaringsdeskundigeOnderzoek> DeelnemersOnderzoek {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Gebruiker & Chat relatie
        modelBuilder.Entity<Gebruiker>()
            .HasMany(u => u.Chats)
            .WithOne(c => c.Verzender)
            .HasForeignKey(c => c.ChatId);

        //Gebruiker&Rol relatie
        modelBuilder.Entity<Gebruiker>()
            .HasMany(u => u.GebruikerRollen)
            .WithOne(ur => ur.Gebruiker)
            .HasForeignKey(ur => ur.GebruikerRolId);

        modelBuilder.Entity<GebruikerRol>()
            .HasOne(ur => ur.Gebruiker)
            .WithMany(u => u.GebruikerRollen)
            .HasForeignKey(ur => ur.GebruikerRolId);

        modelBuilder.Entity<GebruikerRol>()
            .HasOne(ur => ur.Rol)
            .WithMany(r => r.GebruikerRollen)
            .HasForeignKey(ur => ur.RoleId);

        // Chat & Bericht relatie
        modelBuilder.Entity<Chat>()
            .HasMany(c => c.Berichten)
            .WithOne(b => b.Chat)
            .HasForeignKey(b => b.BerichtId);

        // Bedrijf & Onderzoek relatie
        modelBuilder.Entity<Onderzoek>()
            .HasOne(o => o.Bedrijf)
            .WithMany(b => b.Onderzoeken)
            .HasForeignKey(o => o.OnderzoekId);

        // Verzorger & Ervaringsdeskundige relatie
        modelBuilder.Entity<Ervaringsdeskundige>()
            .HasOne(e => e.Verzorger)
            .WithMany(v => v.Ervaringsdeskundige)
            .HasForeignKey(e => e.ErvaringsdeskundigeId);

        // 
        modelBuilder.Entity<Ervaringsdeskundige>()
            .HasMany(e => e.Beschikbaarheid)        
            .WithOne(b => b.Ervaringsdeskundige)     
            .HasForeignKey(b => b.BeschikbaarheidId);

        modelBuilder.Entity<ErvaringsdeskundigeOnderzoek>()
            .HasKey(e => new { e.ErvaringsdeskundigeId, e.OnderzoekId });

        modelBuilder.Entity<ErvaringsdeskundigeOnderzoek>()
            .HasOne(eo => eo.Ervaringsdeskundige)
            .WithMany(e => e.Deelnames)
            .HasForeignKey(eo => eo.ErvaringsdeskundigeId);

        modelBuilder.Entity<ErvaringsdeskundigeOnderzoek>()
            .HasOne(o => o.Onderzoek)
            .WithMany(d => d.Deelnemers)
            .HasForeignKey(e => e.OnderzoekId);

    }
}
