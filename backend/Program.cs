using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Models; // Ga ervan uit dat je modelklassen zich in een namespace genaamd 'Models' bevinden

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "http://localhost","http://localhost:3001")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Laad configuratie uit verschillende bronnen
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddEnvironmentVariables();

// Voeg services toe aan de container.
builder.Services.AddControllers();

// Leer meer over het configureren van Swagger/OpenAPI op https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// Voeg DbContext toe met SQL Server
builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Voeg Identity services toe met gebruikersklasse Gebruiker en rolklasse Rol
builder.Services.AddIdentity<Gebruiker, Rol>()
    .AddEntityFrameworkStores<DbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Voer database migraties uit bij het starten van de toepassing
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Voer migraties uit
        var context = services.GetRequiredService<DbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Behandel fouten, log, enz.
        Console.WriteLine("Fout tijdens migratie: " + ex.Message);
    }
}

// Configureer de HTTP-verzoek-pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("AllowMyOrigin");

app.MapControllers();

// Voeg de rollen toe
CreateRoles(app.Services).Wait();

app.Run();

// Voeg deze methode toe binnen de Program-klasse als static
static async Task CreateRoles(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Rol>>();
        string[] roleNames = { Rol.Beheerder, Rol.Bedrijf, Rol.Ervaringsdeskundige, Rol.Verzorger };

        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                Console.WriteLine($"Creating role: {roleName}");
                roleResult = await roleManager.CreateAsync(new Rol { Name = roleName });
            }
        }

    }
}
