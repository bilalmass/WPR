using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RegistreerVerzorgerController : ControllerBase
    {
        // Verantwoordelijk voor het beheren van het aanmeldingsproces van gebruikers, zoals inloggen, uitloggen en externe aanmelding.
        private readonly SignInManager<Gebruiker> _signInManager;

        // Verantwoordelijk voor het beheren van gebruikers, zoals het maken, verwijderen en ophalen van gebruikers.
        private readonly UserManager<Gebruiker> _userManager;

        // Verantwoordelijk voor het beheren van rollen, zoals het maken, verwijderen en ophalen van rollen.
        private readonly RoleManager<Rol> _roleManager;

        // Constructor om SignInManager, UserManager en RoleManager te initialiseren via Dependency Injection
        public RegistreerVerzorgerController(
            SignInManager<Gebruiker> signInManager,
            UserManager<Gebruiker> userManager,
            RoleManager<Rol> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // HTTP POST-endpoint voor het registreren van een verzorger account
        [HttpPost]
        [Route("VerzorgerRegistreer")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateVerzorgerRequestData request)
        {
            // Controleer of de rol 'Verzorger' bestaat, zo niet, maak de rol aan
            var VerzorgerRolExist = await _roleManager.RoleExistsAsync(Rol.Verzorger);
            if (!VerzorgerRolExist)
            {
                await _roleManager.CreateAsync(new Rol { Name = Rol.Verzorger });
            }

            var user = new Verzorger
            {
                UserName = request.GebruikersNaam,
                Email = request.Email,
                Discriminator = Rol.Verzorger,
                Naam = request.Naam
            };

            var resultCreateUser = await _userManager.CreateAsync(user, request.Wachtwoord);

            if (resultCreateUser.Succeeded)
            {
                // Wijs de rol 'Verzorger' toe aan de gebruiker van het Verzorger
                var resultAddToRole = await _userManager.AddToRoleAsync(user, "Verzorger");

                if (resultAddToRole.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return CreatedAtAction(nameof(CreateAccount), user);
                }
                else
                {
                    return BadRequest(resultAddToRole.Errors);
                }
            }

            return BadRequest(resultCreateUser.Errors);
        }

        // Dataklasse om het registratieverzoek voor een verzorger voor te stellen met validatieattributen
        public class CreateVerzorgerRequestData
        {
            [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "E-mail is verplicht")]
            [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Wachtwoord is verplicht")]
            [MinLength(6, ErrorMessage = "Wachtwoord moet minimaal 6 tekens lang zijn")]
            public string Wachtwoord { get; set; }

            [Required(ErrorMessage = "Naam is verplicht")]
            public string Naam { get; set; }
        }
    }
}
