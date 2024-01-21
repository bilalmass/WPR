using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

public class DbContext : IdentityDbContext<Gebruiker, Rol, int>
{
    public DbContext(DbContextOptions<DbContext> options)
       : base(options)
   {
   }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Server=wprserver.database.windows.net;Database=WPRDB;User Id=DataBaseAdmin;Password=SterkWW369.;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    public DbSet<Bedrijf>? Bedrijven { get; set; }
    public DbSet<Bericht>? Berichten { get; set; }
    public DbSet<Chat>? Chats { get; set; }
    public DbSet<Ervaringsdeskundige>? Ervaringsdeskundigen { get; set; }
    public DbSet<Gebruiker>? Gebruikers { get; set; }
    public DbSet<Onderzoek>? Onderzoeken { get; set; }
    public DbSet<Rol>? Rollen { get; set; }
    public DbSet<Verzorger>? Verzorgers { get; set; }
    public DbSet<Beschikbaarheid>? Beschikbaarheden {get; set;}
    public DbSet<ErvaringsdeskundigeOnderzoek>? DeelnemersOnderzoek {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Gebruiker>()
        .Property(u => u.Discriminator)
        .HasDefaultValue("test");
        
        modelBuilder.Entity<Gebruiker>()
            .HasDiscriminator<string>("UserType")
            .HasValue<Gebruiker>("Gebruiker")
            .HasValue<Ervaringsdeskundige>("Ervaringsdeskundige")
            .HasValue<Verzorger>("Verzorger")
            .HasValue<Bedrijf>("Bedrijf");

    }
}
