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
    }
}