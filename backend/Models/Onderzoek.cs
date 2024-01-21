namespace Models;

public class Onderzoek
{
    public int OnderzoekId {get; set;}
    public string? Titel {get; set;}
    public string? Beschrijving {get; set;}
    public DateTime? Start {get; set;}
    public string? Locatie {get; set;}
    public string? Beloning {get; set;}
    public string? Categorie {get; set;}
    public string? Status {get; set;}
    public string? Type {get; set;}
    public Bedrijf? Bedrijf {get; set;}

    public ICollection<ErvaringsdeskundigeOnderzoek> Deelnemers {get; set;} = new List<ErvaringsdeskundigeOnderzoek>();
}