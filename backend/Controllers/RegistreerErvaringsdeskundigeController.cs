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
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;
        private readonly RoleManager<Rol> _roleManager;

        public RegistreerErvaringsdeskundigeController(
            SignInManager<Gebruiker> signInManager,
            UserManager<Gebruiker> userManager,
            RoleManager<Rol> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

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

            var user = new Gebruiker
            {
                UserName = request.GebruikersNaam,
                Email = request.Email,
                Discriminator = Rol.Ervaringsdeskundige
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


        public class CreateErvaringsdeskundigeRequestData
        {
            [Required(ErrorMessage = "Username is required")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
            public string Wachtwoord { get; set; }
        }
    }
}
