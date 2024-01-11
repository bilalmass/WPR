using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class VerzorgerLoginController : ControllerBase
    {
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;

        public VerzorgerLoginController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("VerzorgerLogin")]
        public async Task<IActionResult> Login([FromBody] VerzorgerLoginRequestData request)
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

        public class VerzorgerLoginRequestData
        {
            [Required(ErrorMessage = "Username is required")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Wachtwoord { get; set; }
        }
    }
}
