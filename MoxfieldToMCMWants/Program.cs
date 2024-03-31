using MoxfieldToMCMWants;

Console.WriteLine("Please insert the URL to a Moxfield deck.");
var url = Console.ReadLine();

// Check if URL matches the http or https URI schemes
if (!(Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
      (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)))
    throw new ArgumentException("Not a valid URL.");

Console.WriteLine("Would you like to retain the exact card editions? (y/n)");
var exactEditionsInput = Console.ReadLine();
if (exactEditionsInput!.ToLower()[0] != 'y' && exactEditionsInput.ToLower()[0] != 'n')
    throw new ArgumentException("Answer was not 'y' or 'n'.");
var exactEditions = exactEditionsInput[0] == 'y';

Console.WriteLine("Exporting Moxfield deck list...");
var config = new Settings();
var deckGrabber = new MoxfieldDeckGrabber(config);
var deck = deckGrabber.ExportDeck(url, exactEditions);
deckGrabber.QuitDriver();

Console.WriteLine(deck.Name);
Console.WriteLine(deck.ToString());

Console.WriteLine("Importing Moxfield deck into MCM Wants...");
var wantListLoader = new MCMWantListPopulator(config);
wantListLoader.AddWantedList(deck);
wantListLoader.QuitDriver();
Console.WriteLine("Done!");
