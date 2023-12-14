namespace Models;

public class Chat
{
    public int ChatID {get; set;}
    public Gebruiker Gebruiker1 {get; set;}
    public Gebruiker Gebruiker2 {get; set;}

    public List<Bericht> Berichten {get; set;}

}