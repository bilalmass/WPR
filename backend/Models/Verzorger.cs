namespace Models;

public class Verzorger : Gebruiker
{
    public string Naam {get; set;}
    public ICollection<Ervaringsdeskundige>? Ervaringsdeskundige {get; set;}
}