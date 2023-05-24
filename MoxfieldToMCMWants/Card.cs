namespace MoxfieldToMCMWants;

public class Card
{
    public Card(string name)
    {
        Name = name;
        Set = null;
        Language = null;
        Condition = null;
        Foil = null;
        Signed = null;
        Altered = null;
        BuyPrice = null;
        EmailAlarm = false;
    }

    public string Name { get; set; }
    public string? Set { get; set; }
    public string? Language { get; set; }
    public string? Condition { get; set; }
    public bool? Foil { get; set; }
    public bool? Signed { get; set; }
    public bool? Altered { get; set; }
    public double? BuyPrice { get; set; }
    public bool EmailAlarm { get; set; }

    public enum Languages
    {
        English,
        French,
        German,
        Spanish,
        Italian,
        SimplifiedChinese,
        Japanese,
        Portuguese,
        Russian,
        Korean,
        TraditionalChinese
    }

    public enum Conditions
    {
        Mint,
        NearMint,
        Excellent,
        Good,
        LightPlayed,
        Played,
        Poor
    }
}
