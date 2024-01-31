using Microsoft.AspNetCore.Mvc;
using Models; // Ga ervan uit dat Gebruiker is gedefinieerd in de Models-namespace
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Controller
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // Verantwoordelijk voor het beheren van gebruikers, zoals het maken, verwijderen en ophalen van gebruikers.
        private readonly UserManager<Gebruiker> _userManager;

        // Verantwoordelijk voor het beheren van het aanmeldingsproces van gebruikers, zoals inloggen, uitloggen en externe aanmelding.
        private readonly SignInManager<Gebruiker> _signInManager;

        // Constructor om SignInManager en UserManager te initialiseren via Dependency Injection
        public LoginController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // HTTP POST-endpoint voor gebruikersaanmelding
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestData request)
        {
                // Probeer de gebruiker aan te melden met opgegeven gebruikersnaam en wachtwoord
                var result = await _signInManager.PasswordSignInAsync(request.GebruikersNaam, request.Wachtwoord, false, lockoutOnFailure: false);

                // Controleer of de aanmeldpoging succesvol was
                if (result.Succeeded)
                {

                // Genereer een JWT
                var claims = new[] { new Claim(ClaimTypes.NameIdentifier, request.GebruikersNaam) };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DeSleutelMoetMinimaal16KaraktersZijn"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                issuer: "WPR-H",
                audience: "WPR-H-Gebruiker",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

                // Geef een succesbericht terug als de aanmelding succesvol is
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {
                // Geef een slecht verzoek terug met een bericht als de aanmelding mislukt
                return BadRequest("Aanmelding mislukt");
            }
        }

        // Dataklasse om het aanmeldingsverzoek voor te stellen met validatieattributen
        public class LoginRequestData
        {
            [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
            public string GebruikersNaam { get; set; }

            [Required(ErrorMessage = "Wachtwoord is verplicht")]
            public string Wachtwoord { get; set; }
        }
    }

    public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = "WPR-H",
                ValidateAudience = true,
                ValidAudience = "WPR-H-Gebruiker",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = handler.ValidateToken(token, validationParameters, out var securityToken);
                var jwtToken = (JwtSecurityToken)securityToken;

                if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                context.User = principal;
            }
            catch
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
        }

        await _next(context);
    }
}
}
