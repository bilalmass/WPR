namespace Models;

using Microsoft.AspNetCore.Identity;

public class Gebruiker : IdentityUser
{
    public string GebruikerId {get; set;}
    public ICollection<Chat>? Chats {get; set;}
    public ICollection<GebruikerRol>? GebruikerRollen {get; set;}

}