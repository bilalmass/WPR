namespace Models;

public class ErvaringsdeskundigeOnderzoek
{
    public int ErvaringsdeskundigeId { get; set; }
    public Ervaringsdeskundige Ervaringsdeskundige { get; set; }

    public int OnderzoekId { get; set; }
    public Onderzoek Onderzoek { get; set; }
}