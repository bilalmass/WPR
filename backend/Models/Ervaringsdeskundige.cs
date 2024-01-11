namespace Models;
public class Ervaringsdeskundige : Gebruiker
{
    public int ErvaringsdeskundigeId {get; set;}
    public string? Voornaam {get; set;}
    public string? Achternaam {get; set;}
    public string? Telefoonnummer {get; set;}
    private DateOnly _Geboortedatum;
    public string Geboortedatum
        {
            get => _Geboortedatum.ToString("yyyy-MM-dd");
            set => _Geboortedatum = DateOnly.Parse(value);
        }
    public string? PostCode {get; set;}
    public string? Geslacht {get; set;}
    public bool? Data {get; set;}
    public ICollection<Beschikbaarheid>? Beschikbaarheid {get; set;}
    public ICollection<Beperking>? Beperkingen {get; set;}
    public ICollection<ErvaringsdeskundigeOnderzoek>? Deelnames {get; set;}
    public Verzorger? Verzorger {get; set;}
}