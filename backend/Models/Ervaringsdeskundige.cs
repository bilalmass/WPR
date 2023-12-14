namespace Models;
public class Ervaringsdeskundige : Gebruiker
{
    public int ErvaringsdeskundigeID {get; set;}
    public string PostCode {get; set;}
    public bool data {get; set;}
    public List<DateTime> Beschikbaarheid {get; set;}
    public List<string> Beperking {get; set;}
}