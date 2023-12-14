namespace Models;

public class Bedrijf : Gebruiker
{
    public List<Onderzoek>? Onderzoeken {get; set;}
}