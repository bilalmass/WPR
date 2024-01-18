using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OnderzoekController : ControllerBase
    {
        private readonly DbContext _dbContext;
        
        public OnderzoekController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("lijst")]
        public IActionResult Index()
        {
            var onderzoeken = _dbContext.Onderzoeken
                .Include(o => o.Bedrijf)
                .Include(o => o.Deelnemers)
                .ToList();


            return Ok(onderzoeken);
        }
    }
}