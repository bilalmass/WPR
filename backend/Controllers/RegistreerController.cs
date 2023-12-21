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
    private readonly DbContext _context;
    private readonly SignInManager<Gebruiker> _signInManager;
    private readonly UserManager<Gebruiker> _userManager;

    public AccountController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager, DbContext context)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _context = context;
    }

    [HttpPost]
    [Route("nog doen")]
    public async Task<IActionResult> CreateBedrijf([FromBody] RegistreerBedrijf request)
    {
        var user = new Gebruiker{ UserName = request.GebruikersNaam, Email = request.Email};
        var result = await _userManager.CreateAsync(user, request.Wachtwoord);

        return result.Succeeded ? StatusCode(201) : new BadRequestObjectResult(result);
    }

    [HttpPost]
    [Route("ervaringsdeskundige")]
    public async Task<IActionResult> RegistreerErvaringsDeskundige([FromBody] RegistreerRequestData data)
    {
        var user = new Ervaringsdeskundige {Voornaam = data.Voornaam, Achternaam = data.Achternaam, Email = data.Email, Telefoonnummer = data.Telefoonnummer, Geboortedatum = data.Geboortedatum, Geslacht = data.Geslacht};
        var result = await _userManager.CreateAsync(user, data.Wachtwoord);

        return result.Succeeded ? StatusCode(201) : new BadRequestObjectResult(result);
    }
    public class RegistreerBedrijf
    {
        [Required(ErrorMessage = "Username is required")]
        public string GebruikersNaam {get; set;}
        [Required(ErrorMessage = "Email is required")]
        public string Email {get; set;}
        [Required(ErrorMessage = "Password is required")]
        public string Wachtwoord {get; set;}
    }

    public class RegistreerRequestData
    {
        [Required(ErrorMessage = "Vul je voornaam in")]
        public string Voornaam {get; set;}
        [Required(ErrorMessage = "Vul je achternaam in")]
        public string Achternaam {get; set;}
        [Required(ErrorMessage = "Vul je email in")]
        public string Email {get; set;}
        [Required(ErrorMessage = "Vul je telefoonnummer in")]
        public string Telefoonnummer {get; set;}        
        [Required(ErrorMessage = "Vul je Wachtwoord in")]
        public string Wachtwoord {get; set;}
        [Required(ErrorMessage = "Vul je geboortedatum in")]
        public DateOnly Geboortedatum {get; set;}
        [Required(ErrorMessage = "Vul je geslacht in")]
        public string Geslacht {get; set;}
    }
}
}