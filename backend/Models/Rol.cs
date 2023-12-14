using Microsoft.AspNetCore.Identity;

namespace Models;

public class Rol : IdentityRole
{
    public ICollection<GebruikerRol> GebruikerRollen {get; set;}
}