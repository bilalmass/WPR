namespace Models;

public class Verzorger : Gebruiker
{
    public string VerzorgerId {get; set;}
    public ICollection<Ervaringsdeskundige>? Ervaringsdeskundige {get; set;}
}