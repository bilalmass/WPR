using Microsoft.AspNetCore.Identity;

namespace Models;

public class GebruikerRol : IdentityUserRole<String>
{
    public int GebruikerRolId {get; set;}
    public Gebruiker Gebruiker {get; set;}
    public Rol Rol {get; set;}
}