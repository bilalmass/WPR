namespace Models;

public class Bedrijf : Gebruiker
{
    public int BedrijfId {get; set;}
    public ICollection<Onderzoek>? Onderzoeken {get; set;}
}