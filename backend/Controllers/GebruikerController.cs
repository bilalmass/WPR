using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
        public IActionResult Index()
        {
            var gebruikers = _dbContext.Gebruikers
                .Include(o => o.UserName)
                .Include(o => o.GebruikerId)
                .Include(o => o.Voornaam)
                .Include(o => o.Achternaam)
                .Include(o => o.PhoneNumber)
                .ToList();


            return Ok(gebruikers);
        }
    }
}