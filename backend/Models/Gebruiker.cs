namespace Models;

using Microsoft.AspNetCore.Identity;

public class Gebruiker : IdentityUser
{
    public string GebruikerId {get; set;}
    public string Voornaam {get; set;}
    public string Achternaam {get; set;}
    public ICollection<Chat>? Chats {get; set;}
    public ICollection<GebruikerRol>? GebruikerRollen {get; set;}

}