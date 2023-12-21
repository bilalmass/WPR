namespace Models;

public class Verzorger : Gebruiker
{
    public int VerzorgerId {get; set;}
    public ICollection<Ervaringsdeskundige> Ervaringsdeskundige {get; set;}
}