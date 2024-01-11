using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ErvaringsdeskundigeLoginController : ControllerBase
    {
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;

        public ErvaringsdeskundigeLoginController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] ErvaringsdeskundigeLoginRequestData request)
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

        public class ErvaringsdeskundigeLoginRequestData
        {
            [Required(ErrorMessage = "Username is required")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Wachtwoord { get; set; }
        }
    }
}
