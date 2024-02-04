using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

[Route("[controller]")]
[ApiController]
public class OnderzoekController : ControllerBase
{
    private readonly DbContext _context;
    public OnderzoekController(DbContext context)
    {
        _context = context;
    }

    // Aanmaken onderzoek (Create)
    [HttpPost("create")]
    [Authorize(Roles = "Bedrijf,Beheerder")]
    public async Task<IActionResult> CreateOnderzoek([FromBody] CreateOnderzoekRequestData request)
    {
     //    Controleer of de ingelogde gebruiker een "Bedrijf" of "Beheerder" is
       if (!User.IsInRole("Bedrijf") && !User.IsInRole("Beheerder"))
       {
           return Forbid(); // Gebruiker heeft niet de juiste rol, verbied toegang
       }

        // Haal de ID van de ingelogde gebruiker op
       var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        //Zoek het Bedrijf object dat overeenkomt met de ingelogde gebruiker
       var bedrijf = await _context.Bedrijven.FirstOrDefaultAsync(b => b.Id == userId);
        if (bedrijf == null)
        {
            return BadRequest("De ingelogde gebruiker is geen bedrijf.");
        }

        var onderzoek = new Onderzoek
        {
            Titel = request.Titel,
            Beschrijving = request.Beschrijving,
            Start = request.Start,
            Categorie = request.Categorie,
            Beloning = request.Beloning,
            Status = "Open",
            Bedrijf = bedrijf // Koppel het Bedrijf aan het Onderzoek
        };

        await _context.Onderzoeken.AddAsync(onderzoek);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOnderzoek), new { id = onderzoek.OnderzoekId }, onderzoek);
    }

    //Return alle onderzoeken (Read)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoek()
    {
        return await _context.Onderzoeken.ToListAsync();
    }

    [HttpGet("{onderzoekId}/deelnemers")]
    public async Task<ActionResult<IEnumerable<Ervaringsdeskundige>>> GetDeelnemers(int onderzoekId)
    {
        var onderzoek = await _context.Onderzoeken
            .Include(o => o.Deelnemers)
            .ThenInclude(d => d.Ervaringsdeskundige)
            .FirstOrDefaultAsync(o => o.OnderzoekId == onderzoekId);

        if (onderzoek == null)
        {
            return NotFound();
        }

        var deelnemers = onderzoek.Deelnemers
            .Select(d => d.Ervaringsdeskundige)
            .ToList();

        return Ok(deelnemers);
    }

    //Aanpassen van Onderzoek (Update)
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateOnderzoek(int id, [FromBody] UpdateOnderzoekRequestData request)
    {
        var onderzoek = await _context.Onderzoeken.FindAsync(id);
        if (onderzoek == null)
        {
            return NotFound("Onderzoek niet gevonden");
        }

        if (request.Titel != null && request.Titel != "") onderzoek.Titel = request.Titel;
        if (request.Beschrijving != null && request.Beschrijving != "") onderzoek.Beschrijving = request.Beschrijving;
        if (request.Categorie != null && request.Categorie != "") onderzoek.Categorie = request.Categorie;
        if (request.Beloning != null && request.Beloning != "") onderzoek.Beloning = request.Beloning;

        onderzoek.Start = request.Start;

        await _context.SaveChangesAsync();

        return Ok(new { message = "Onderzoek bijgewerkt" });
    }

    //Verwijder onderzoek (Delete)
    [HttpDelete("{onderzoekId}")]
    public async Task<IActionResult> DeleteOnderzoek(int onderzoekId)
    {
        var onderzoek = await _context.Onderzoeken.FindAsync(onderzoekId);
        if (onderzoek == null)
        {
            return NotFound();
        }

        _context.Onderzoeken.Remove(onderzoek);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Onderzoek succesvol verwijdert" });
    }

    // Methode om het specifieke onderzoek op te halen (voor CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<Onderzoek>> GetOnderzoek(int id)
    {
        var onderzoek = await _context.Onderzoeken.FindAsync(id);
        if (onderzoek == null)
        {
            return NotFound();
        }
        return onderzoek;
    }

    [HttpPost("register/{onderzoekId}")]
    public async Task<IActionResult> RegisterForOnderzoek(int onderzoekId)
    {
        // Haal de ID van de ingelogde gebruiker op
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        // Zoek het Onderzoek object dat overeenkomt met de gegeven onderzoekId
        var onderzoek = await _context.Onderzoeken.FirstOrDefaultAsync(o => o.OnderzoekId == onderzoekId);
        if (onderzoek == null)
        {
            return NotFound("Onderzoek niet gevonden");
        }

        // Zoek het Ervaringsdeskundige object dat overeenkomt met de ingelogde gebruiker
        var ervaringsdeskundige = await _context.Ervaringsdeskundigen.FirstOrDefaultAsync(e => e.Id == userId);
        if (ervaringsdeskundige == null)
        {
            return BadRequest("De ingelogde gebruiker is geen ervaringsdeskundige.");
        }

        // Voeg de ervaringsdeskundige toe aan het onderzoek
        onderzoek.Deelnemers.Add(new ErvaringsdeskundigeOnderzoek
        {
            Ervaringsdeskundige = ervaringsdeskundige,
            Onderzoek = onderzoek
        });

        await _context.SaveChangesAsync();

        return Ok(new { message = "Je bent succesvol ingeschreven voor het onderzoek." });
    }

}
public class CreateOnderzoekRequestData
    {
        public string Titel { get; set; }
        public string Beschrijving {get; set;}
        public DateTime Start { get; set; }
        public string Categorie {get; set;}
        public string Beloning {get; set;}
    }

public class UpdateOnderzoekRequestData
    {
        public string? Titel { get; set; }
        public string? Beschrijving { get; set; }
        public DateTime Start { get; set; }
        public string? Categorie { get; set; }
        public string? Beloning { get; set; }
        
    }