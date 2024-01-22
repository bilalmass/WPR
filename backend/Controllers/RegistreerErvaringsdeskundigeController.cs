using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RegistreerErvaringsdeskundigeController : ControllerBase
    {
        // Verantwoordelijk voor het beheren van het aanmeldingsproces van gebruikers, zoals inloggen, uitloggen en externe aanmelding.
        private readonly SignInManager<Gebruiker> _signInManager;

        // Verantwoordelijk voor het beheren van gebruikers, zoals het maken, verwijderen en ophalen van gebruikers.
        private readonly UserManager<Gebruiker> _userManager;

        // Verantwoordelijk voor het beheren van rollen, zoals het maken, verwijderen en ophalen van rollen.
        private readonly RoleManager<Rol> _roleManager;

        // Constructor om SignInManager, UserManager en RoleManager te initialiseren via Dependency Injection
        public RegistreerErvaringsdeskundigeController(
            SignInManager<Gebruiker> signInManager,
            UserManager<Gebruiker> userManager,
            RoleManager<Rol> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // HTTP POST-endpoint voor het registreren van een ervaringsdeskundige account
        [HttpPost]
        [Route("ErvaringsdeskundigeRegistreer")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateErvaringsdeskundigeRequestData request)
        {
            // Controleer of de rol 'Ervaringsdeskundige' bestaat, zo niet, maak de rol aan
            var ErvaringsdeskundigeRolExist = await _roleManager.RoleExistsAsync(Rol.Ervaringsdeskundige);
            if (!ErvaringsdeskundigeRolExist)
            {
                await _roleManager.CreateAsync(new Rol { Name = Rol.Ervaringsdeskundige });
            }

            var user = new Ervaringsdeskundige
            {
                UserName = request.GebruikersNaam,
                Email = request.Email,
                Discriminator = Rol.Ervaringsdeskundige,
                Voornaam = request.Voornaam,
                Achternaam = request.Achternaam,
                Telefoonnummer = request.Telefoonnummer,
                Geboortedatum = request.Geboortedatum,
                PostCode = request.PostCode,
                Geslacht = request.Geslacht
            };

            var resultCreateUser = await _userManager.CreateAsync(user, request.Wachtwoord);

            if (resultCreateUser.Succeeded)
            {
                // Wijs de rol 'Ervaringsdeskundige' toe aan de gebruiker van het Ervaringsdeskundige
                var resultAddToRole = await _userManager.AddToRoleAsync(user, "Ervaringsdeskundige");

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

        // Dataklasse om het registratieverzoek voor een ervaringsdeskundige voor te stellen met validatieattributen
        public class CreateErvaringsdeskundigeRequestData
        {
            [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "E-mail is verplicht")]
            [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Wachtwoord is verplicht")]
            [MinLength(6, ErrorMessage = "Wachtwoord moet minimaal 6 tekens lang zijn")]
            public string Wachtwoord { get; set; }

            [Required(ErrorMessage = "Voornaam is verplicht")]
            public string Voornaam { get; set; }

            [Required(ErrorMessage = "Achternaam is verplicht")]
            public string Achternaam { get; set; }

            [Required(ErrorMessage = "Telefoonnummer is verplicht")]
            public string Telefoonnummer { get; set; }

            [Required(ErrorMessage = "Geboortedatum is verplicht")]
            public string Geboortedatum { get; set; }

            [Required(ErrorMessage = "Postcode is verplicht")]
            public string PostCode { get; set; }

            [Required(ErrorMessage = "Geslacht is verplicht")]
            public string Geslacht { get; set; }
        }
    }
}
