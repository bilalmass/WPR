namespace Models;

using Microsoft.AspNetCore.Identity;

public class Gebruiker : IdentityUser
{
    
    public ICollection<Chat>? Chats {get; set;}
    public ICollection<Rol>? GebruikerRollen {get; set;}

}