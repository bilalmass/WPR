using Models;

public class Beschikbaarheid
{
    public int BeschikbaarheidId {get; set;}
    public Ervaringsdeskundige? Ervaringsdeskundige {get; set;}
    public DateTime? Begin {get; set;}
    public DateTime? Eind {get; set;}
}