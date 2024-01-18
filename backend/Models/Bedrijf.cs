namespace Models;

public class Bedrijf : Gebruiker
{
    public string Naam {get; set;}
    public ICollection<Onderzoek> Onderzoeken {get; set;}
}