namespace Models;

public class Bedrijf : Gebruiker
{
    public ICollection<Onderzoek> Onderzoeken {get; set;}
}