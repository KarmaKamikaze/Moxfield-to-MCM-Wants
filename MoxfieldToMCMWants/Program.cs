using MoxfieldToMCMWants;

Console.WriteLine("Please insert the URL to a Moxfield deck.");
string? url = Console.ReadLine();

// Check if URL matches the http or https URI schemes
if (!(Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
      (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)))
    throw new ArgumentException("Not a valid URL.");

Console.WriteLine("Would you like to retain the exact card editions? (y/n)");
string? exactEditionsInput = Console.ReadLine();
if (exactEditionsInput!.ToLower()[0] != 'y' && exactEditionsInput.ToLower()[0] != 'n')
    throw new ArgumentException("Answer was not 'y' or 'n'.");
bool exactEditions = exactEditionsInput[0] == 'y';

Console.WriteLine("Exporting Moxfield deck list...");
Settings config = new Settings();
MoxfieldDeckGrabber deckGrabber = new MoxfieldDeckGrabber(config);
Deck deck = deckGrabber.ExportDeck(url, exactEditions);
deckGrabber.QuitDriver();


Console.WriteLine(deck.Name);
foreach (KeyValuePair<Card,int> card in deck.DeckList)
{
    Console.WriteLine($"{card.Value} {card.Key.Name}");
}
