using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

// DbContext die IdentityDbContext van Gebruiker, Rol en int uitbreidt
public class DbContext : IdentityDbContext<Gebruiker, Rol, int>
{
    // Constructor om DbContext te initialiseren met DbContextOptions
    public DbContext(DbContextOptions<DbContext> options)
       : base(options)
   {
   }

    // Configuratiemethode voor DbContext-options
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Verbindingsreeks voor de database (let op: bewaar gevoelige informatie veilig)
            string connectionString = "Server=wprserver.database.windows.net;Database=WPRDB;User Id=DataBaseAdmin;Password=SterkWW369.;";

            // Gebruik SQL Server als de databaseprovider met de opgegeven verbindingsreeks
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    // DbSet-properties voor elke entiteit in de database
    public DbSet<Bedrijf>? Bedrijven { get; set; }
    public DbSet<Bericht>? Berichten { get; set; }
    public DbSet<Chat>? Chats { get; set; }
    public DbSet<Ervaringsdeskundige>? Ervaringsdeskundigen { get; set; }
    public DbSet<Gebruiker>? Gebruikers { get; set; }
    public DbSet<Onderzoek>? Onderzoeken { get; set; }
    public DbSet<Rol>? Rollen { get; set; }
    public DbSet<Verzorger>? Verzorgers { get; set; }
    public DbSet<Beschikbaarheid>? Beschikbaarheden { get; set; }
    public DbSet<ErvaringsdeskundigeOnderzoek>? DeelnemersOnderzoek { get; set; }

    // Methode voor het configureren van het model
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Stel de standaardwaarde voor Discriminator in op "test" voor Gebruiker
        modelBuilder.Entity<Gebruiker>()
            .Property(u => u.Discriminator)
            .HasDefaultValue("test");
        
        // Configureer het discriminatiepad en voeg de waarden voor verschillende entiteittypen toe
        modelBuilder.Entity<Gebruiker>()
            .HasDiscriminator<string>("UserType")
            .HasValue<Gebruiker>("Gebruiker")
            .HasValue<Ervaringsdeskundige>("Ervaringsdeskundige")
            .HasValue<Verzorger>("Verzorger")
            .HasValue<Bedrijf>("Bedrijf");
    }
}
