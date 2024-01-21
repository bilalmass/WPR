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

        // POST: /bedrijf/profiel/update
        // [HttpPut("bedrijfprofiel/update")]
        // public async Task<IActionResult> UpdateProfielAsync([FromBody] Bedrijf updatedBedrijf)
        // {
        //     var bedrijf = await _context.Bedrijven.FirstOrDefaultAsync();
        //     if (bedrijf == null)
        //     {
        //         return NotFound("Bedrijven niet gevonden");
        //     }

        //     bedrijf.Naam = updatedBedrijf.Naam;

        //     await _context.SaveChangesAsync();

        //     return Ok("Bedrijfsprofiel succesvol bijgewerkt");
        // }

        [Authorize(Roles = "BedrijfRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBedrijfProfile(int id, [FromBody] BedrijfUpdateModel model)
        {
            var bedrijf = await _context.Bedrijven.FindAsync(id);
            if (bedrijf == null)
            {
                return NotFound();
            }

            if(model.Naam != null) bedrijf.Naam = model.Naam;
            // ... andere properties?

            _context.Bedrijven.Update(bedrijf);
            await _context.SaveChangesAsync();

            return Ok(bedrijf); 
        }

        // BedrijfUpdateModel.cs
        public class BedrijfUpdateModel
        {
            public string? Naam { get; set; }
            // andere properties?
        }


        // GET: /bedrijf/onderzoeken
        [HttpGet("onderzoeken")]
        public async Task<IActionResult> OnderzoekenOverzichtAsync([FromBody] int bedrijfId)
        {
            var bedrijfOnderzoeken = await _context.Onderzoeken
                .Where(o => o.Bedrijf.GebruikerId == bedrijfId)
                .ToListAsync();
            if (!bedrijfOnderzoeken.Any())
            {
                return NotFound("Geen onderzoeken gevonden voor dit bedrijf");
            }

            return Ok(bedrijfOnderzoeken);
        }  

        // GET: /bedrijf/onderzoeken/{onderzoekId}
        [HttpGet("onderzoeken/{onderzoekId}")]
        public async Task<IActionResult> OnderzoekDetailsAsync([FromBody] int onderzoekId)
        {
            var onderzoek = await _context.Onderzoeken
                .FirstOrDefaultAsync(o => o.OnderzoekId == onderzoekId);
            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden");
            }

            return Ok(onderzoek);
        }

        // POST: /bedrijf/onderzoeken/nieuw
        [HttpPost("onderzoeken/nieuw")]
        public async Task<IActionResult> NieuwOnderzoekToevoegenAsync([FromBody] Onderzoek onderzoek)
        {
            await _context.Onderzoeken.AddAsync(onderzoek);
            await _context.SaveChangesAsync();

            return Ok("Nieuw onderzoek toegevoegd");
        }

        // PUT: /bedrijf/onderzoeken/{onderzoekId}/bewerken
        [HttpPut("onderzoeken/{onderzoekId}/bewerken")]
        public async Task<IActionResult> OnderzoekBijwerkenAsync(int onderzoekId, [FromBody] Onderzoek bijgewerktOnderzoek)
        {
            var onderzoek = await _context.Onderzoeken
                .FirstOrDefaultAsync(o => o.OnderzoekId == onderzoekId);
            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden");
            }

            onderzoek.Titel = bijgewerktOnderzoek.Titel;
            await _context.SaveChangesAsync();

            return Ok("Onderzoek succesvol bijgewerkt");
        }

        // DELETE: /bedrijf/onderzoeken/{onderzoekId}/verwijderen
        [HttpDelete("onderzoeken/{onderzoekId}/verwijderen")]
        public async Task<IActionResult> OnderzoekVerwijderenAsync([FromBody] int onderzoekId)
        {
            var onderzoek = await _context.Onderzoeken
                .FirstOrDefaultAsync(o => o.OnderzoekId == onderzoekId);
            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden");
            }

            _context.Onderzoeken.Remove(onderzoek);
            await _context.SaveChangesAsync();

            return Ok("Onderzoek succesvol verwijderd");
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
            var deelnemer = await _context.DeelnemersOnderzoek.FirstOrDefaultAsync(d => d.Ervaringsdeskundige.GebruikerId == deelnemerId);

            if (deelnemer == null)
            {
                return NotFound($"Deelnemer met ID {deelnemerId} niet gevonden");
            }
            return Ok(deelnemer);
        }
        
        public class CreateBedrijfModel
        {
            public string Email { get; set; }
            public string Bedrijfsnaam { get; set; } 
        }

    }
}
