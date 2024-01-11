namespace Models;

public class Bedrijf : Gebruiker
{
    public string BedrijfId {get; set;}
    public ICollection<Onderzoek>? Onderzoeken {get; set;}
}