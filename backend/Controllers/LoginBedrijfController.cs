using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class BedrijfLoginController : ControllerBase
    {
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;
        private readonly DbContext _context;

        public BedrijfLoginController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager, DbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        [Route("BedrijfLogin")]
        public async Task<IActionResult> Login([FromBody] BedrijfLoginRequestData request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.GebruikersNaam, request.Wachtwoord, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok("Login successful");
            }
            else
            {
                return BadRequest("Login failed");
            }
        }

        public class BedrijfLoginRequestData
        {
            [Required(ErrorMessage = "Username is required")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Wachtwoord { get; set; }
        }
    }
}
