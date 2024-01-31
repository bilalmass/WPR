using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AccessibilityApi.Controllers
{
    [Route("bedrijf")]
    [ApiController]
    public class BedrijfsController : ControllerBase
    {
        private readonly DbContext _context;

        public BedrijfsController(DbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: /bedrijf/profiel
        [HttpGet("profiel")]
        public async Task<IActionResult> ProfielAsync()
        {
            var bedrijfsProfiel = await _context.Bedrijven.FirstOrDefaultAsync();
            if (bedrijfsProfiel == null)
            {
                return NotFound("Bedrijfsprofiel niet gevonden");
            }
            return Ok(bedrijfsProfiel);
        }

        [HttpPut("bedrijfprofiel/update")]
        public IActionResult UpdateProfiel([FromBody] BedrijfsProfielUpdateModel model)
        {
            try
            {
                var bedrijf = _context.Bedrijven.FirstOrDefault(b => b.Id == model.GebruikerId);

                if (bedrijf == null)
                    return NotFound("Bedrijf niet gevonden");

                if (!string.IsNullOrEmpty(model.Bedrijfsnaam))
                    bedrijf.Naam = model.Bedrijfsnaam;

                if (!string.IsNullOrEmpty(model.Informatie))
                    bedrijf.Informatie = model.Informatie;

                if (!string.IsNullOrEmpty(model.Locatie))
                    bedrijf.Locatie = model.Locatie;

                if (!string.IsNullOrEmpty(model.Link))
                    bedrijf.Link = model.Link;

                _context.SaveChanges();

                return Ok("Bedrijfsprofiel succesvol bijgewerkt");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Er is een fout opgetreden: {ex.Message}");
            }
        }

        public class BedrijfsProfielUpdateModel
        {
            public int GebruikerId { get; set; }
            public string? Bedrijfsnaam { get; set; }
            public string? Informatie { get; set; }
            public string? Locatie { get; set; }
            public string? Link { get; set; }

        }
        
        // GET: /bedrijf/onderzoeken
        [HttpGet("onderzoeken")]
        public async Task<IActionResult> OnderzoekenOverzichtAsync([FromBody] int bedrijfId)
        {
            var bedrijfOnderzoeken = await _context.Onderzoeken
                .Where(o => o.Bedrijf.Id == bedrijfId)
                .ToListAsync();
            if (!bedrijfOnderzoeken.Any())
            {
                return NotFound("Geen onderzoeken gevonden voor dit bedrijf");
            }

            return Ok(bedrijfOnderzoeken);
        }  

        // GET: /bedrijf/opdrachten/chat/{deelnemerId}
        [HttpGet("opdrachten/chat/{deelnemerId}")]
        public IActionResult ChatMetDeelnemers([FromBody] int deelnemerId)
        {
            // Chat moet nog gefixt worden
            return null;
        }

        // GET: /bedrijf/deelnemer/{deelnemerId}/profiel
        [HttpGet("deelnemer/{deelnemerId}/profiel")]
        public async Task<IActionResult> BekijkProfielDeelnemerAsync([FromBody] int deelnemerId)
        {
            var deelnemer = await _context.DeelnemersOnderzoek.FirstOrDefaultAsync(d => d.Ervaringsdeskundige.Id == deelnemerId);

            if (deelnemer == null)
            {
                return NotFound($"Deelnemer met ID {deelnemerId} niet gevonden");
            }
            return Ok(deelnemer);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBedrijf(int id)
        {
            var bedrijf = await _context.Bedrijven.FindAsync(id);
            if (bedrijf == null)
            {
                return NotFound();
            }

            _context.Bedrijven.Remove(bedrijf);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
