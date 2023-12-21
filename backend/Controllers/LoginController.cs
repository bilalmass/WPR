using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Identity;

[Route("/login")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<Gebruiker> _UserManager;
    private readonly SignInManager<Gebruiker> _SignInManager;
    private readonly DbContext _Context;

    public AuthController(UserManager<Gebruiker> userManager, SignInManager<Gebruiker> signInManager, DbContext context)
    {
        _UserManager = userManager;
        _SignInManager = signInManager;
        _Context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] GebruikerLogin login)
    {
        var _user = await _UserManager.FindByNameAsync(login.UserName);
        if (_user != null)
        {
            await _SignInManager.SignInAsync(_user, true);
            return Ok();
        }

        return Unauthorized();
    }
}
    

public class GebruikerLogin
{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; }
}