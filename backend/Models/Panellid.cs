namespace Models;
public class Panellid : Gebruiker
{
    public int PanellidID {get; set;}
    public string PostCode {get; set;}
    public bool Data {get; set;}
    public List<string> Beperking {get; set;}
    public List<Onderzoek> Deelnames {get; set;}
}