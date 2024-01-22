
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace Models;

public class Gebruiker : IdentityUser<int>
{
    public int GebruikerId {get; set;}
    public string? Voornaam {get; set;}
    public string? Achternaam {get; set;}
    public string? Geboortedatum {get; set;}
    public string? Geslacht {get; set;}
    public ICollection<Chat>? Chats {get; set;}
    public ICollection<Rol>? GebruikerRollen {get; set;}
    public string Discriminator{get; set;}
}
