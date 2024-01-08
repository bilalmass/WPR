using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RegistreerBeheerderController : ControllerBase
    {
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;

        public RegistreerBeheerderController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("registreer")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequestData request)
        {
            var user = new Gebruiker { UserName = request.GebruikersNaam, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Wachtwoord);

            return result.Succeeded ? CreatedAtAction(nameof(CreateAccount), user) : BadRequest(result.Errors);
        }

        public class CreateAccountRequestData
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
