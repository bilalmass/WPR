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
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;

        private readonly RoleManager<Rol> _roleManager;

        public RegistreerVerzorgerController(
            SignInManager<Gebruiker> signInManager,
            UserManager<Gebruiker> userManager,
            RoleManager<Rol> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;

        }

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


        public class CreateVerzorgerRequestData
        {
            [Required(ErrorMessage = "Username is required")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
            public string Wachtwoord { get; set; }

            [Required(ErrorMessage = "Naam is required")]
            public string Naam { get; set; }
        }
    }
}
