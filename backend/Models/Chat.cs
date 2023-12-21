namespace Models;

public class Chat
{
    public int ChatId {get; set;}
    public Gebruiker Verzender {get; set;}
    public ICollection<Bericht> Berichten {get; set;}

}