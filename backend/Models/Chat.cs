namespace Models;

public class Chat
{
    public string ChatId {get; set;}
    public Gebruiker? Verzender {get; set;}
    public ICollection<Bericht>? Berichten {get; set;}

}