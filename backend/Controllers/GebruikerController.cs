using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Models;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public GebruikerController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("lijst")]

        public List<Gebruiker> GetGebruikers()
        {
            List<Gebruiker> gebruikers = _dbContext.Gebruikers.ToList();

            return gebruikers;
        }

        [HttpGet]
        [Route("discriminator/{username}")]
        public ActionResult<string> GetGebruikerDiscriminator(string username)
        {
            var discriminator = _dbContext.Gebruikers
                .Where(u => u.UserName == username)
                .Select(u => u.Discriminator)
                .FirstOrDefault();

            if (discriminator == null)
            {
                return NotFound();
            }

            return Ok(discriminator);
        }

        
        [HttpDelete]
        [Route("verwijderalleusers")]
        public void VerwijderGebruikers()
        {
            _dbContext.Gebruikers.RemoveRange(_dbContext.Gebruikers);
            _dbContext.SaveChanges();
        }
        
        [HttpGet]
        [Route("gebruikerinfo/{username}")]
        public ActionResult<Gebruiker> GetGebruikerInfo(string username)
        {
            var gebruiker = _dbContext.Gebruikers.FirstOrDefault(u => u.UserName == username);

            if (gebruiker == null)
            {
                return NotFound();
            }

            return Ok(gebruiker);
        }
        [HttpDelete]
        [Route("verwijderen/{username}")]
        public IActionResult VerwijderAccount(string username)
        {
            var account = _dbContext.Gebruikers.FirstOrDefault(u => u.UserName == username);

            if (account == null)
            {
                return NotFound();
            }

            _dbContext.Gebruikers.Remove(account);
            _dbContext.SaveChanges();

            return NoContent();
        }
        public class UpdateEmailModel
        {
            public string NieuweEmail { get; set; }
            public string NieuweTelefoon { get; set; }
        }

        [HttpPut]
        [Route("bijwerken/{username}")]
        public IActionResult BijwerkenGebruiker([FromBody] UpdateEmailModel model, string username)
        {
            var gebruiker = _dbContext.Gebruikers.FirstOrDefault(u => u.UserName == username);

            if (gebruiker == null)
            {
                return NotFound();
            }

            gebruiker.Email = model.NieuweEmail;
            gebruiker.PhoneNumber = model.NieuweTelefoon;
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
    
}