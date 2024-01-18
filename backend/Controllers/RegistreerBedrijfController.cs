using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RegistreerBedrijfController : ControllerBase
    {
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;
        private readonly RoleManager<Rol> _roleManager;

        public RegistreerBedrijfController(
            SignInManager<Gebruiker> signInManager,
            UserManager<Gebruiker> userManager,
            RoleManager<Rol> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("BedrijfRegistreer")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateBedrijfRequestData request)
        {
            // Controleer of de rol 'Bedrijf' bestaat, zo niet, maak de rol aan
            var bedrijfRolExist = await _roleManager.RoleExistsAsync(Rol.Bedrijf);
            if (!bedrijfRolExist)
            {
                await _roleManager.CreateAsync(new Rol { Name = Rol.Bedrijf });
            }

            var user = new Gebruiker
            {
                UserName = request.GebruikersNaam,
                Email = request.Email,
                Discriminator = Rol.Bedrijf
            };

            var resultCreateUser = await _userManager.CreateAsync(user, request.Wachtwoord);

            if (resultCreateUser.Succeeded)
            {
                // Wijs de rol 'Bedrijf' toe aan de gebruiker van het bedrijf
                var resultAddToRole = await _userManager.AddToRoleAsync(user, "Bedrijf");

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


        public class CreateBedrijfRequestData
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
