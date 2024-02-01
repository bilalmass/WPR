using Microsoft.AspNetCore.Mvc;
using Models; // Ga ervan uit dat Gebruiker is gedefinieerd in de Models-namespace
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // Verantwoordelijk voor het beheren van gebruikers, zoals het maken, verwijderen en ophalen van gebruikers.
        private readonly UserManager<Gebruiker> _userManager;

        // Verantwoordelijk voor het beheren van het aanmeldingsproces van gebruikers, zoals inloggen, uitloggen en externe aanmelding.
        private readonly SignInManager<Gebruiker> _signInManager;

        // Constructor om SignInManager en UserManager te initialiseren via Dependency Injection
        public LoginController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // HTTP POST-endpoint voor gebruikersaanmelding
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestData request)
        {
            // Probeer de gebruiker aan te melden met opgegeven gebruikersnaam en wachtwoord
            var result = await _signInManager.PasswordSignInAsync(request.GebruikersNaam, request.Wachtwoord, false, lockoutOnFailure: false);

            // Controleer of de aanmeldpoging succesvol was
            if (result.Succeeded)
            {
                // Return a success message as a JSON object
                return Ok(new { Success = true, Message = "Aanmelding succesvol" });
            }
            else
            {
                // Return a failure message as a JSON object
                return BadRequest(new { Success = false, Message = "Aanmelding mislukt" });
            }

        }

        // Dataklasse om het aanmeldingsverzoek voor te stellen met validatieattributen
        public class LoginRequestData
        {
            [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "Wachtwoord is verplicht")]
            public string Wachtwoord { get; set; }
        }
    }
}
