namespace Models;

public class ErvaringsdeskundigeOnderzoek
{
    public string ErvaringsdeskundigeId { get; set; }
    public Ervaringsdeskundige? Ervaringsdeskundige { get; set; }

    public string OnderzoekId { get; set; }
    public Onderzoek? Onderzoek { get; set; }
}