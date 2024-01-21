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

    [HttpGet]
    [Route("onderzoek")]
    public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoek()
    {
        return await _context.Onderzoeken.Where(d => d.Start > DateTime.Now).ToListAsync();
    }

    // In your OnderzoekController.cs

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

    [HttpGet]
    [Route("datum")]
    public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoekDatum()
    {
        return await _context.Onderzoeken.OrderBy(d => d.Start).ToListAsync();
    }

    [HttpGet]
    [Route("populariteit")]
    public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoekPopulariteit()
    {
        return await _context.Onderzoeken.OrderBy(p => p.Titel).ToListAsync(); // Titel veranderen naar Populariteit
    }
    [HttpGet]
    [Route("getall")]
    public async Task<ActionResult<IEnumerable<Onderzoek>>> GetAllOnderzoeken()
    {
        return await _context.Onderzoeken.ToListAsync();
    }
    [HttpPut]
    [Route("update/{id}")]
    public async Task<IActionResult> SluitOnderzoek(int id, [FromBody] UpdateOnderzoekRequestData request)
    {
        var onderzoek = await _context.Onderzoeken.FindAsync(id);
        if (onderzoek == null)
        {
            return NotFound();
        }

        onderzoek.Status = "Gesloten";

        await _context.SaveChangesAsync();

        return Ok(new { message = "Onderzoek bijgewerkt" });
    }
    [HttpPut]
    [Route("open/{id}")]
    public async Task<IActionResult> OpenOnderzoek(int id, [FromBody] UpdateOnderzoekRequestData request)
    {
        var onderzoek = await _context.Onderzoeken.FindAsync(id);
        if (onderzoek == null)
        {
            return NotFound();
        }

        onderzoek.Status = "Open";

        await _context.SaveChangesAsync();

        return Ok(new { message = "Onderzoek bijgewerkt" });
    }

    public class UpdateOnderzoekRequestData
    {
        public string Status { get; set; }
    }
    [HttpPost]
    [Route("create")]
    [Authorize(Roles = "Bedrijf,Beheerder")]
    public async Task<IActionResult> CreateOnderzoek([FromBody] CreateOnderzoekRequestData request)
    {
        // Controleer of de ingelogde gebruiker een "Bedrijf" of "Beheerder" is
        if (!User.IsInRole("Bedrijf") && !User.IsInRole("Beheerder"))
        {
            return Forbid(); // Gebruiker heeft niet de juiste rol, verbied toegang
        }

        // Haal de ID van de ingelogde gebruiker op
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        // Zoek het Bedrijf object dat overeenkomt met de ingelogde gebruiker
        var bedrijf = await _context.Bedrijven.FirstOrDefaultAsync(b => b.GebruikerId == userId);
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
            Bedrijf = bedrijf // Koppel het Bedrijf aan het Onderzoek
        };

        await _context.Onderzoeken.AddAsync(onderzoek);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOnderzoek), new { id = onderzoek.OnderzoekId }, onderzoek);
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


}
public class CreateOnderzoekRequestData
{
    public string Titel { get; set; }
    public string Beschrijving {get; set;}
    public DateTime Start { get; set; }
    public string Categorie {get; set;}
    public string Beloning {get; set;}
}