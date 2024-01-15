using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Rol : IdentityRole
    {
        public const string Beheerder = "Beheerder";
        public const string Bedrijf = "Bedrijf";
        public const string Ervaringsdeskundige = "Ervaringsdeskundige";
        public const string Verzorger = "Verzorger";
    }
}
