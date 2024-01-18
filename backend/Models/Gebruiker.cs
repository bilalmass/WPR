namespace Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

public class Gebruiker : IdentityUser
{
<<<<<<< HEAD
    public int GebruikerId {get; set;}
    public ICollection<Chat>? Chats {get; set;}
    public ICollection<GebruikerRol>? GebruikerRollen {get; set;}

}
=======
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override string Id { get; set; }
    public ICollection<Chat>? Chats { get; set; }
    
    // Discriminator toevoegen
    public string Discriminator { get; set; }
}
>>>>>>> 72cc4759ef79e5dea24cdbd65b13e6b423cc0bae
