namespace Models;
public class Ervaringsdeskundige : Gebruiker
{
    public int ErvaringsdeskundigeId {get; set;}
    public string PostCode {get; set;}
    public bool Data {get; set;}
    public ICollection<Beschikbaarheid> Beschikbaarheid {get; set;}
    public ICollection<Beperking> Beperkingen {get; set;}
    public ICollection<ErvaringsdeskundigeOnderzoek> Deelnames {get; set;}
    public Verzorger? Verzorger {get; set;}
}