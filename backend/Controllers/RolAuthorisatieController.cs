using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JouwProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RolAuthorisatieController : ControllerBase
    {
        [Authorize(Roles = "Verzorger")]
        [HttpGet("NaamInvullenVerzorger")]
        public IActionResult NaamInvullenVerzorger()
        {
            var data = new { message = "Naam invullen voor Verzorger" };
            return Ok(data);
        }

        [Authorize(Roles = "Bedrijf")]
        [HttpGet("NaamInvullenBedrijf")]
        public IActionResult NaamInvullenBedrijf()
        {
            var data = new { message = "Naam invullen voor Bedrijf" };
            return Ok(data);
        }

        [Authorize(Roles = "Beheerder")]
        [HttpGet("NaamInvullenBeheerder")]
        public IActionResult NaamInvullenBeheerder()
        {
            var data = new { message = "Naam invullen voor Beheerder" };
            return Ok(data);
        }

        [Authorize(Roles = "Ervaringsdeskundige")]
        [HttpGet("NaamInvullenErvaringsdeskundige")]
        public IActionResult NaamInvullenErvaringsdeskundige()
        {
            var data = new { message = "Naam invullen voor Ervaringsdeskundige" };
            return Ok(data);
        }
    }
}
