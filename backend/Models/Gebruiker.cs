namespace Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

public class Gebruiker : IdentityUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override string Id { get; set; }
    public ICollection<Chat>? Chats { get; set; }
    
    // Discriminator toevoegen
    public string Discriminator { get; set; }
}
