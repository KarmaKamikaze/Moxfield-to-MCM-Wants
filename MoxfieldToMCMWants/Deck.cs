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
    private bool _keepEditions = false;

    public void ConstructDeckList(string deckList, bool keepEditions)
    {
        Dictionary<Card, int> deck = new Dictionary<Card, int>();

        // Card example: 3 Island (3ed) 295
        string[] cards = deckList.Split('\n');
        foreach (string card in cards)
        {
            if(card.Contains("SIDEBOARD:")) // Skip sideboard cards
                break;

            List<string> fields = card.Split(' ').ToList();
            if (!Int32.TryParse(fields[0], out int amount))
                break;

            string cardName = string.Empty;
            for (int i = 1; i < fields.Count; i++) // skip first field since it is a number
            {
                if (fields[i].Contains('(') || fields[i].Contains(')')) // Stop when seeing edition marker
                    break;
                if (i == 1) // No space at the beginning of the card name
                    cardName += fields[i];
                else
                    cardName += $" {fields[i]}";
            }
            Card newCard = new Card(cardName);

            if (keepEditions)
            {
                _keepEditions = true;
                string edition = fields.Find(s => s.Contains('('))!
                    .Replace("(", "")
                    .Replace(")", "");
                newCard.Set = edition;
            }

            deck.Add(newCard, amount);
        }

        DeckList = deck;
    }

    public override string ToString()
    {
        var result = String.Empty;
        foreach (var card in DeckList)
        {
            result += $"{card.Value} {card.Key.Name}";
            if (_keepEditions)
            {
                result += $" ({card.Key.Set})";
            }

            result += '\n';
        }
        return result;
    }
}
