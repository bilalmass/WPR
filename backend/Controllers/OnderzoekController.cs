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
    [Route("voorstellingen")]
    public async Task<ActionResult<IEnumerable<Onderzoek>>> GetOnderzoek()
    {
        return await _context.Onderzoeken.Where(d => d.Start > DateTime.Now).ToListAsync();
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

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateOnderzoek([FromBody] CreateOnderzoekRequestData request)
    {
        var v = new Onderzoek
        {
            Titel = request.Titel,
            Beschrijving = request.Beschrijving,
            Start = request.Start,
            Categorie = request.Categorie,
            Beloning = request.Beloning
        };

        await _context.Onderzoeken.AddAsync(v);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(request.Titel, new { id = v.OnderzoekId }, request);
        //  return await result.Succeeded ? new BadRequestObjectResult(result) : StatusCode(201);
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