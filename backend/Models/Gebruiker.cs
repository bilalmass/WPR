namespace Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

public class Gebruiker : IdentityUser<int>
{
    public int GebruikerId {get; set;}
    public ICollection<Chat>? Chats {get; set;}
    public ICollection<Rol>? GebruikerRollen {get; set;}
    public string Discriminator{get; set;}


}
