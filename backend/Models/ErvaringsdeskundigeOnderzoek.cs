namespace Models;

public class ErvaringsdeskundigeOnderzoek
{
    public int ErvaringsdeskundigeOnderzoekId { get; set; }
    public Ervaringsdeskundige? Ervaringsdeskundige { get; set; }
    public Onderzoek? Onderzoek { get; set; }
}