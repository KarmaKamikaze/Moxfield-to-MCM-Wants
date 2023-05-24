namespace MoxfieldToMCMWants;

public class Deck
{
    public Deck(string name, string url)
    {
        Name = name;
        Url = url;
        DeckList = new Dictionary<Card, int>();
    }

    public string Name { get; set; }
    public string Url { get; set; }
    public Dictionary<Card, int> DeckList { get; set; }
}
