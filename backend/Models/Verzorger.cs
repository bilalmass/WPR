namespace Models;

public class Verzorger : Gebruiker
{
    public ICollection<Ervaringsdeskundige>? Ervaringsdeskundige {get; set;}
}