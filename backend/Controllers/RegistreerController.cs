using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Controller
{

[Route("[controller]")]
[ApiController]

public class AccountController : ControllerBase
{
    //private readonly DatabaseContext _context;
    private readonly SignInManager<Gebruiker> _signInManager;
    private readonly UserManager<Gebruiker> _userManager;

    public AccountController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager)//, DatabaseContext context)
    {
        _signInManager = signInManager;
        _userManager = userManager;
       // _context = context;
    }

    [HttpPost]
    [Route("registreer")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequestData request)
    {
        var user = new Gebruiker{ UserName = request.GebruikersNaam, Email = request.Email};
        var result = await _userManager.CreateAsync(user, request.Wachtwoord);

        return result.Succeeded ? StatusCode(201) : new BadRequestObjectResult(result);
    }

    public class CreateAccountRequestData
    {
        [Required(ErrorMessage = "Username is required")]
        public string GebruikersNaam {get; set;}
        [Required(ErrorMessage = "Email is required")]
        public string Email {get; set;}
        [Required(ErrorMessage = "Password is required")]
        public string Wachtwoord {get; set;}
    }
}
}