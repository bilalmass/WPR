using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Models
{
    public class Rol : IdentityRole<int>
    {
        public int RolId {get; set;}
        public const string Beheerder = "Beheerder";
        public const string Bedrijf = "Bedrijf";
        public const string Ervaringsdeskundige = "Ervaringsdeskundige";
        public const string Verzorger = "Verzorger";

    }
}