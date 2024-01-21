namespace Models;

public class Bedrijf : Gebruiker
{
    public string? Naam {get; set;}
    public ICollection<Onderzoek>? Onderzoeken {get; set;}
    public string? Informatie {get; set;}
    public string? Locatie {get; set;}
    public string? Link {get; set;}
}